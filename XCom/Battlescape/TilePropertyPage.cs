﻿using System;
using System.Linq;
using System.Runtime.InteropServices;
using XCom.Content.Maps.TilePropertyPages;

namespace XCom.Battlescape
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct TilePropertyPage
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
		public BattleLocationPartType TileType;
		public byte ExplosiveType;
		public byte ExplosiveStrength;
		public byte Unused6;
		public byte BurnTurnCount;
		public byte Brightness;
		public byte SpecialProperties;
		[MarshalAs(UnmanagedType.I1)]
		public bool IsCriticalForFacility;
		public byte Unused7;

		private static TilePropertyPage[] LoadTilePropertyPages(byte[] data)
		{
			var recordSize = Marshal.SizeOf(typeof(TilePropertyPage));
			var count = data.Length / recordSize;
			if (data.Length % recordSize != 0)
				throw new InvalidOperationException("Invalid property page resource size.");
			return Enumerable.Range(0, count)
				.Select(index => index * recordSize)
				.Select(data.ReadStruct<TilePropertyPage>)
				.ToArray();
		}

		public static readonly TilePropertyPage[] Common = LoadTilePropertyPages(TilePropertyPages.Common);
		public static readonly TilePropertyPage[] Forest = LoadTilePropertyPages(TilePropertyPages.Forest);
	}
}
