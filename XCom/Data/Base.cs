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
				ResearchProjects = new List<ResearchProject>()
			};
		}

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

		public int GetTotalMaintenance()
		{
			return Facilities
				.Select(facility => facility.FacilityType.Metadata())
				.Sum(metadata => metadata.Maintenance);
		}

		public int GetTotalLaboratorySpace()
		{
			return CountFacilities(FacilityType.Laboratory) * 50;
		}

		public int GetScientistsAllocated()
		{
			return ResearchProjects.Sum(research => research.ScientistsAllocated);
		}

		public int GetScientistsAvailable()
		{
			return ScientistCount - GetScientistsAllocated();
		}

		public int GetLaboratorySpaceAvailable()
		{
			return GetTotalLaboratorySpace() - GetScientistsAllocated();
		}

		public Facility FindFacilityAt(int row, int column, bool allowUnderConstruction)
		{
			return Facilities.FirstOrDefault(facility => facility.IsAt(row, column, allowUnderConstruction));
		}
	}
}
