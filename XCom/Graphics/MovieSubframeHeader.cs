using System.Runtime.InteropServices;

namespace XCom.Graphics
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct SubframeHeader
	{
		public uint Size;
		public ushort SubframeType;

		public const ushort TypeColor64 = 11;
		public const ushort TypeDelta = 12;
		public const ushort TypeByteRun = 15;
	}
}
