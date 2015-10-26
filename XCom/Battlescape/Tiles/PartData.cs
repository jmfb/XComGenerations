using System;
using System.Linq;
using System.Runtime.InteropServices;
using XCom.Content.Maps.TileParts;

namespace XCom.Battlescape.Tiles
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct PartData
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
		public byte[] Images;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
		public byte[] LineOfFireTemplates;
		public ushort MiniMapIndex;
		public int Unused1;
		public int Unused2;
		[MarshalAs(UnmanagedType.I1)]
		public bool IsSlidingDoor;
		[MarshalAs(UnmanagedType.I1)]
		public bool BlocksVisibility;
		[MarshalAs(UnmanagedType.I1)]
		public bool CannotStandOn;
		[MarshalAs(UnmanagedType.I1)]
		public bool IsWall;
		[MarshalAs(UnmanagedType.I1)]
		public bool IsElevator;
		[MarshalAs(UnmanagedType.I1)]
		public bool IsHingedDoor;
		[MarshalAs(UnmanagedType.I1)]
		public bool BlocksFire;
		[MarshalAs(UnmanagedType.I1)]
		public bool BlocksSmoke;
		public byte Unused3;
		public byte WalkingTimeUnits;
		public byte SlidingTimeUnits;
		public byte FlyingTimeUnits;
		public byte Armor;
		public byte HighExplosiveDefense;
		public byte DeathTile;
		public byte Flammability;
		public byte OpenDoorTile;
		public byte Unused4;
		public byte VerticalUnitOffset;
		public byte VerticalImageOffset;
		public byte Unused5;
		public byte LightBlockage;
		public byte FootstepSoundEffect;
		public PartType TileType;
		public byte ExplosiveType;
		public byte ExplosiveStrength;
		public byte Unused6;
		public byte BurnTurnCount;
		public byte Brightness;
		public byte SpecialProperties;
		[MarshalAs(UnmanagedType.I1)]
		public bool IsCriticalForFacility;
		public byte Unused7;

		private static PartData[] LoadParts(byte[] data)
		{
			var recordSize = Marshal.SizeOf(typeof(PartData));
			var count = data.Length / recordSize;
			if (data.Length % recordSize != 0)
				throw new InvalidOperationException("Invalid property page resource size.");
			return Enumerable.Range(0, count)
				.Select(index => index * recordSize)
				.Select(data.ReadStruct<PartData>)
				.ToArray();
		}

		public static readonly PartData[] Common = LoadParts(TileParts.Common);

		public static readonly PartData[] Skyranger = LoadParts(TileParts.Skyranger);
		public static readonly PartData[] Lightning = LoadParts(TileParts.Lightning);
		public static readonly PartData[] Avenger = LoadParts(TileParts.Avenger);

		public static readonly PartData[] XcomBase = LoadParts(TileParts.XcomBase);
		public static readonly PartData[] XcomFacilities = LoadParts(TileParts.XcomFacilities);

		public static readonly PartData[] AlienBase = LoadParts(TileParts.AlienBase);
		public static readonly PartData[] Brain = LoadParts(TileParts.Brain);
		public static readonly PartData[] UfoSmallScout = LoadParts(TileParts.UfoSmallScout);
		public static readonly PartData[] UfoExterior = LoadParts(TileParts.UfoExterior);
		public static readonly PartData[] UfoBits = LoadParts(TileParts.UfoBits);
		public static readonly PartData[] UfoComponents = LoadParts(TileParts.UfoComponents);
		public static readonly PartData[] UfoEquipment = LoadParts(TileParts.UfoEquipment);
		public static readonly PartData[] UfoExaminationRoom = LoadParts(TileParts.UfoExaminationRoom);
		public static readonly PartData[] UfoOperatingTable = LoadParts(TileParts.UfoOperatingTable);

		public static readonly PartData[] City = LoadParts(TileParts.City);
		public static readonly PartData[] CityBits = LoadParts(TileParts.CityBits);
		public static readonly PartData[] Roads = LoadParts(TileParts.Roads);
		public static readonly PartData[] Furniture = LoadParts(TileParts.Furniture);

		public static readonly PartData[] Barn = LoadParts(TileParts.Barn);
		public static readonly PartData[] Cultivation = LoadParts(TileParts.Cultivation);
		public static readonly PartData[] Desert = LoadParts(TileParts.Desert);
		public static readonly PartData[] Forest = LoadParts(TileParts.Forest);
		public static readonly PartData[] Jungle = LoadParts(TileParts.Jungle);
		public static readonly PartData[] Mountain = LoadParts(TileParts.Mountain);
		public static readonly PartData[] Polar = LoadParts(TileParts.Polar);

		public static readonly PartData[] Mars = LoadParts(TileParts.Mars);
	}
}
