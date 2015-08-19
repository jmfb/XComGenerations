﻿using System.Collections.Generic;
using XCom.Content.Images.Facilities;
using XCom.Graphics;

namespace XCom.Data
{
	public enum FacilityType
	{
		AccessLift,
		LivingQuarters,
		Laboratory,
		Workshop,
		SmallRadarSystem,
		LargeRadarSystem,
		MissileDefenses,
		GeneralStores,
		AlienContainment,
		LaserDefenses,
		PlasmaDefenses,
		FusionBallDefenses,
		GravShield,
		MindShield,
		PsionicLaboratory,
		HyperWaveDecoder,
		Hangar
	}

	public static class FacilityTypeExtensions
	{
		public static FacilityMetadata Metadata(this FacilityType facilityType)
		{
			return metadata[facilityType];
		}

		private static readonly FacilityMetadata accessLift = new FacilityMetadata
		{
			Name = "Access Lift",
			Shape = FacilityShape.Octagon,
			DaysToConstruct = 0,
			Cost = 0,
			Maintenance = 4000,
			Image = new Image(Facilities.AccessLift),
			RowOffset = 7,
			ColumnOffset = 7
		};

		private static readonly FacilityMetadata livingQuarters = new FacilityMetadata
		{
			Name = "Living Quarters",
			Shape = FacilityShape.Square,
			DaysToConstruct = 16,
			Cost = 400000,
			Maintenance = 10000,
			Image = new Image(Facilities.LivingQuarters),
			RowOffset = 3,
			ColumnOffset = 2
		};

		private static readonly FacilityMetadata laboratory = new FacilityMetadata
		{
			Name = "Laboratory",
			Shape = FacilityShape.Square,
			DaysToConstruct = 26,
			Cost = 750000,
			Maintenance = 30000,
			Image = new Image(Facilities.Laboratory),
			RowOffset = 3,
			ColumnOffset = 3
		};

		private static readonly FacilityMetadata workshop = new FacilityMetadata
		{
			Name = "Workshop",
			Shape = FacilityShape.Square,
			DaysToConstruct = 32,
			Cost = 800000,
			Maintenance = 35000,
			Image = new Image(Facilities.Workshop),
			RowOffset = 3,
			ColumnOffset = 3
		};

		private static readonly FacilityMetadata smallRadarSystem = new FacilityMetadata
		{
			Name = "Small Radar System",
			Shape = FacilityShape.Octagon,
			DaysToConstruct = 12,
			Cost = 500000,
			Maintenance = 10000,
			Image = new Image(Facilities.SmallRadarSystem),
			RowOffset = 3,
			ColumnOffset = 3
		};

		private static readonly FacilityMetadata largeRadarSystem = new FacilityMetadata
		{
			Name = "Large Radar System",
			Shape = FacilityShape.Square,
			DaysToConstruct = 25,
			Cost = 800000,
			Maintenance = 15000,
			Image = new Image(Facilities.LargeRadarSystem),
			RowOffset = 3,
			ColumnOffset = 3
		};

		private static readonly FacilityMetadata missileDefenses = new FacilityMetadata
		{
			Name = "Missile Defenses",
			Shape = FacilityShape.Octagon,
			DaysToConstruct = 16,
			Cost = 200000,
			Maintenance = 5000,
			Image = new Image(Facilities.MissileDefenses),
			RowOffset = 6,
			ColumnOffset = 6
		};

		private static readonly FacilityMetadata generalStores = new FacilityMetadata
		{
			Name = "General Stores",
			Shape = FacilityShape.Square,
			DaysToConstruct = 10,
			Cost = 150000,
			Maintenance = 5000,
			Image = new Image(Facilities.GeneralStores),
			RowOffset = 2,
			ColumnOffset = 2
		};

		private static readonly FacilityMetadata alienContainment = new FacilityMetadata
		{
			Name = "Alien Containment",
			Shape = FacilityShape.Square,
			DaysToConstruct = 18,
			Cost = 400000,
			Maintenance = 15000,
			Image = new Image(Facilities.AlienContainment),
			RowOffset = 3,
			ColumnOffset = 3
		};

		private static readonly FacilityMetadata laserDefenses = new FacilityMetadata
		{
			Name = "Laser Defenses",
			Shape = FacilityShape.Cross,
			DaysToConstruct = 24,
			Cost = 400000,
			Maintenance = 15000,
			Image = new Image(Facilities.LaserDefenses),
			RowOffset = 5,
			ColumnOffset = 5,
			RequiredResearch = ResearchType.LaserDefenses
		};

		private static readonly FacilityMetadata plasmaDefenses = new FacilityMetadata
		{
			Name = "Plasma Defenses",
			Shape = FacilityShape.Cross,
			DaysToConstruct = 34,
			Cost = 600000,
			Maintenance = 12000,
			Image = new Image(Facilities.PlasmaDefenses),
			RowOffset = 5,
			ColumnOffset = 5,
			RequiredResearch = ResearchType.PlasmaDefenses
		};

		private static readonly FacilityMetadata fusionBallDefenses = new FacilityMetadata
		{
			Name = "Fusion Ball Defenses",
			Shape = FacilityShape.Cross,
			DaysToConstruct = 34,
			Cost = 800000,
			Maintenance = 14000,
			Image = new Image(Facilities.FusionBallDefenses),
			RowOffset = 4,
			ColumnOffset = 4,
			RequiredResearch = ResearchType.FusionDefenses
		};

		private static readonly FacilityMetadata gravShield = new FacilityMetadata
		{
			Name = "Grav Shield",
			Shape = FacilityShape.Octagon,
			DaysToConstruct = 38,
			Cost = 1200000,
			Maintenance = 15000,
			Image = new Image(Facilities.GravShield),
			RowOffset = 2,
			ColumnOffset = 2,
			RequiredResearch = ResearchType.GravShield
		};

		private static readonly FacilityMetadata mindShield = new FacilityMetadata
		{
			Name = "Mind Shield",
			Shape = FacilityShape.Octagon,
			DaysToConstruct = 33,
			Cost = 1300000,
			Maintenance = 5000,
			Image = new Image(Facilities.MindShield),
			RowOffset = 3,
			ColumnOffset = 3,
			RequiredResearch = ResearchType.MindShield
		};

		private static readonly FacilityMetadata psionicLaboratory = new FacilityMetadata
		{
			Name = "Psionic Laboratory",
			Shape = FacilityShape.Square,
			DaysToConstruct = 24,
			Cost = 750000,
			Maintenance = 16000,
			Image = new Image(Facilities.PsionicLaboratory),
			RowOffset = 4,
			ColumnOffset = 4,
			RequiredResearch = ResearchType.PsiLab
		};

		private static readonly FacilityMetadata hyperWaveDecoder = new FacilityMetadata
		{
			Name = "Hyper-wave Decoder",
			Shape = FacilityShape.Octagon,
			DaysToConstruct = 26,
			Cost = 1400000,
			Maintenance = 30000,
			Image = new Image(Facilities.HyperWaveDecoder),
			RowOffset = 3,
			ColumnOffset = 3,
			RequiredResearch = ResearchType.HyperwaveDecoder
		};

		private static readonly FacilityMetadata hangar = new FacilityMetadata
		{
			Name = "Hangar",
			Shape = FacilityShape.Hangar,
			DaysToConstruct = 25,
			Cost = 200000,
			Maintenance = 25000,
			Image = new Image(Facilities.Hangar),
			RowOffset = 0,
			ColumnOffset = 0
		};

		private static readonly Dictionary<FacilityType, FacilityMetadata> metadata = new Dictionary<FacilityType,FacilityMetadata>
		{
			{ FacilityType.AccessLift, accessLift },
			{ FacilityType.LivingQuarters, livingQuarters },
			{ FacilityType.Laboratory, laboratory },
			{ FacilityType.Workshop, workshop },
			{ FacilityType.SmallRadarSystem, smallRadarSystem },
			{ FacilityType.LargeRadarSystem, largeRadarSystem },
			{ FacilityType.MissileDefenses, missileDefenses },
			{ FacilityType.GeneralStores, generalStores },
			{ FacilityType.AlienContainment, alienContainment },
			{ FacilityType.LaserDefenses, laserDefenses },
			{ FacilityType.PlasmaDefenses, plasmaDefenses },
			{ FacilityType.FusionBallDefenses, fusionBallDefenses },
			{ FacilityType.GravShield, gravShield },
			{ FacilityType.MindShield, mindShield },
			{ FacilityType.PsionicLaboratory, psionicLaboratory },
			{ FacilityType.HyperWaveDecoder, hyperWaveDecoder },
			{ FacilityType.Hangar, hangar }
		};
	}
}
