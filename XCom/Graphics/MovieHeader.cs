using System.Runtime.InteropServices;

namespace XCom.Graphics
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct MovieHeader
	{
		public uint Size;
		public ushort MovieType;
		public ushort FrameCount;
		public ushort Width;
		public ushort Height;
		public ushort Depth;
		public ushort Flags;
		public uint Speed;
		public ushort Reserved1;
		public uint Created;
		public uint Creator;
		public uint Updated;
		public uint Updater;
		public ushort AspectDx;
		public ushort AspectDy;
		public ushort ExtraFlags;
		public ushort KeyFrames;
		public ushort TotalFrames;
		public uint RequiredMemory;
		public ushort MaxRegions;
		public ushort TransparencyNum;
		public ulong Reserved2;
		public ulong Reserved3;
		public ulong Reserved4;
		public uint OFrame1;
		public uint OFrame2;
		public ulong Reserved5;
		public ulong Reserved6;
		public ulong Reserved7;
		public ulong Reserved8;
		public ulong Reserved9;
	}
}
