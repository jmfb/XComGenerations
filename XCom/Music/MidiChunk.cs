using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace XCom.Music
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct MidiChunk
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public byte[] ChunkTypeBytes;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public byte[] ChunkLengthBigEndian;

		public string ChunkTypeString => new string(ChunkTypeBytes.Select(value => (char)value).ToArray());
		public MidiChunkType ChunkType
		{
			get
			{
				switch (ChunkTypeString)
				{
				case "MThd":
					return MidiChunkType.Header;
				case "MTrk":
					return MidiChunkType.Track;
				default:
					return MidiChunkType.Other;
				}
			}
		}
		public uint ChunkLength => BitConverter.ToUInt32(ChunkLengthBigEndian.Reverse().ToArray(), 0);
	}
}
