using System.Runtime.InteropServices;

namespace XCom.Graphics
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct MovieFrameHeader
	{
		public uint Size;
		public ushort FrameType;
		public ushort ChunkCount;
		public ushort Delay;
		public ushort Reserved;
		public ushort Width;
		public ushort Height;
	}
}
