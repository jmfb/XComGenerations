using System.Collections.Generic;
using System.Linq;

namespace XCom.Data
{
	public class Base
	{
		public string Name { get; set; }
		public string Area { get; set; }

		public List<Facility> Facilities { get; set; }

		public int EngineerCount { get; set; }
		public int ScientistCount { get; set; }
		public List<Craft> Crafts { get; set; }
		public List<Soldier> Soldiers { get; set; }
		public Stores Stores { get; set; }
		public List<ResearchProject> ResearchProjects { get; set; }
		public List<ManufactureProject> ManufactureProjects { get; set; }

		public static Base Create(string name, string area)
		{
			return new Base
			{
				Area = area,
				Name = name,
				Facilities = new List<Facility>(),
				Crafts = new List<Craft>(),
				Soldiers = new List<Soldier>(),
				Stores = Stores.Create(),
				ResearchProjects = new List<ResearchProject>(),
				ManufactureProjects = new List<ManufactureProject>()
			};
		}

		public int PersonnelCount => Soldiers.Count + EngineerCount + ScientistCount;

		public int CountFacilities(FacilityType facilityType)
		{
			return Facilities.Count(facility =>
				facility.DaysUntilConstructionComplete == 0 &&
				facility.FacilityType == facilityType);
		}

		public int CountCrafts(CraftType craftType)
		{
			return Crafts.Count(craft => craft.CraftType == craftType);
		}

		public int TotalMaintenance => Facilities
			.Where(facility => facility.DaysUntilConstructionComplete == 0)
			.Sum(facility => facility.FacilityType.Metadata().Maintenance);

		public int TotalStorageSpace => CountFacilities(FacilityType.GeneralStores) * 50;

		public int StorageSpaceAvailable => TotalStorageSpace - Stores.Space;

		public int TotalLivingSpace => CountFacilities(FacilityType.LivingQuarters) * 50;

		public int LivingSpaceAvailable => TotalLivingSpace - PersonnelCount;

		public int TotalLaboratorySpace => CountFacilities(FacilityType.Laboratory) * 50;

		public int ScientistsAllocated => ResearchProjects.Sum(research => research.ScientistsAllocated);

		public int ScientistsAvailable => ScientistCount - ScientistsAllocated;

		public int LaboratorySpaceAvailable => TotalLaboratorySpace - ScientistsAllocated;

		public int TotalWorkshopSpace => CountFacilities(FacilityType.Workshop) * 50;

		public int EngineersAllocated => ManufactureProjects.Sum(project => project.EngineersAllocated);

		public int EngineersAvailable => EngineerCount - EngineersAllocated;

		private int WorkshopSpaceUsed => ManufactureProjects.Sum(project => project.ManufactureType.Metadata().SpaceRequired);

		public int WorkshopSpaceAvailable => TotalWorkshopSpace - EngineersAllocated - WorkshopSpaceUsed;

		public int TotalHangarSpace => CountFacilities(FacilityType.Hangar);

		public int HangarSpaceAvailable => TotalHangarSpace - Crafts.Count;

		public Facility FindFacilityAt(int row, int column, bool allowUnderConstruction)
		{
			return Facilities.FirstOrDefault(facility => facility.IsAt(row, column, allowUnderConstruction));
		}

		public bool IsFacilityInUse(Facility facility)
		{
			if (facility.DaysUntilConstructionComplete > 0)
				return false;
			switch (facility.FacilityType)
			{
			case FacilityType.Hangar:
				return HangarSpaceAvailable < 1;

			case FacilityType.LivingQuarters:
				return LivingSpaceAvailable < 50;

			case FacilityType.Laboratory:
				return LaboratorySpaceAvailable < 50;

			case FacilityType.Workshop:
				return WorkshopSpaceAvailable < 50;

			case FacilityType.GeneralStores:
				//TODO: general store capacity in excess of stores
				return false;

			case FacilityType.AccessLift:
				var otherFacilitiesAreAttached = Facilities.Count > 1;
				var isOnlyBase = GameState.Current.Data.Bases.Count == 1;
				return otherFacilitiesAreAttached || isOnlyBase;
			}
			return false;
		}

		public bool CanDismantleFacility(Facility facility)
		{
			var facilityConnectivity = new FacilityConnectivity();
			facilityConnectivity.Enter(Facilities.Single(accessLift => accessLift.FacilityType == FacilityType.AccessLift));
			facilityConnectivity.Destroy(facility);
			facilityConnectivity.Explore();
			return Facilities
				.Where(remainingFacility => remainingFacility != facility)
				.All(remainingFacility => facilityConnectivity.IsReachable(remainingFacility));
		}

		private class FacilityConnectivity
		{
			private const int rowCount = 6;
			private const int columnCount = 6;
			private enum Status { None, Dead, Visited, Reachable };
			private readonly Status[][] facilities = Enumerable.Range(0, rowCount)
				.Select(index => Enumerable.Repeat(Status.None, columnCount).ToArray())
				.ToArray();

			public void Explore()
			{
				while (facilities.Any(rows => rows.Any(facility => facility == Status.Reachable)))
					foreach (var row in Enumerable.Range(0, rowCount))
						foreach (var column in Enumerable.Range(0, columnCount))
							if (facilities[row][column] == Status.Reachable)
								Visit(row, column);
			}

			private void Visit(int row, int column)
			{
				var facility = GameState.SelectedBase.FindFacilityAt(row, column, false);
				MarkFacility(facility, Status.Visited);
				MarkNeighbors(facility);
			}

			private void MarkNeighbors(Facility facility)
			{
				var size = facility.FacilityType.Metadata().Shape.Size();
				foreach (var index in Enumerable.Range(0, size))
				{
					MarkNeighbor(facility.Row - 1, facility.Column + index);
					MarkNeighbor(facility.Row + size, facility.Column + index);
					MarkNeighbor(facility.Row + index, facility.Column - 1);
					MarkNeighbor(facility.Row + index, facility.Column + size);
				}
			}

			private void MarkNeighbor(int row, int column)
			{
				if (row < 0 || row >= rowCount)
					return;
				if (column < 0 || column >= columnCount)
					return;
				var neighbor = GameState.SelectedBase.FindFacilityAt(row, column, true);
				if (neighbor != null && facilities[row][column] == Status.None)
					MarkFacility(neighbor, neighbor.DaysUntilConstructionComplete == 0 ? Status.Reachable : Status.Visited);
			}

			public void Enter(Facility accessLift)
			{
				MarkFacility(accessLift, Status.Reachable);
			}

			public void Destroy(Facility facility)
			{
				MarkFacility(facility, Status.Dead);
			}

			public bool IsReachable(Facility facility)
			{
				return facilities[facility.Row][facility.Column] == Status.Visited;
			}

			private void MarkFacility(Facility facility, Status status)
			{
				var size = facility.FacilityType.Metadata().Shape.Size();
				foreach (var row in Enumerable.Range(facility.Row, size))
					foreach (var column in Enumerable.Range(facility.Column, size))
						facilities[row][column] = status;
			}
		}

	}
}
