using System.Runtime.InteropServices;

namespace XCom
{
	public static class StructExtensions
	{
		public static byte[] GetBytes<T>(this T value) where T : struct
		{
			var size = Marshal.SizeOf(value);
			var bytes = new byte[size];
			var memory = Marshal.AllocHGlobal(size);
			Marshal.StructureToPtr(value, memory, true);
			Marshal.Copy(memory, bytes, 0, size);
			Marshal.FreeHGlobal(memory);
			return bytes;
		}
	}
}
