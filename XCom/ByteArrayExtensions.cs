using System.Runtime.InteropServices;

namespace XCom
{
	public static class ByteArrayExtensions
	{
		public static T ReadStruct<T>(this byte[] data, int offset) where T : struct
		{
			var size = Marshal.SizeOf(typeof(T));
			var memory = Marshal.AllocHGlobal(size);
			Marshal.Copy(data, offset, memory, size);
			var value = Marshal.PtrToStructure(memory, typeof(T));
			Marshal.FreeHGlobal(memory);
			return (T)value;
		}
	}
}
