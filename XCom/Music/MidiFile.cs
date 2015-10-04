using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace XCom.Music
{
	public class MidiFile
	{
		private ushort Format { get; set; }
		private ushort TrackCount { get; set; }
		public ushort TicksPerBeat { get; set; }
		public List<MidiTrack> Tracks { get; } = new List<MidiTrack>();

		public MidiFile(byte[] data)
		{
			var headerChunk = data.ReadStruct<MidiChunk>(0);
			if (headerChunk.ChunkType != MidiChunkType.Header)
				throw new InvalidOperationException("Missing midi header chunk.");
			var offset = Marshal.SizeOf(headerChunk);
			LoadHeaderData(data.Skip(offset).Take((int)headerChunk.ChunkLength).ToArray());
			offset += (int)headerChunk.ChunkLength;
			while (offset < data.Length)
			{
				var chunk = data.ReadStruct<MidiChunk>(offset);
				offset += Marshal.SizeOf(chunk);
				switch (chunk.ChunkType)
				{
				case MidiChunkType.Track:
					Tracks.Add(new MidiTrack(data.Skip(offset).Take((int)chunk.ChunkLength).ToArray()));
					break;
				case MidiChunkType.Other:
					break;
				case MidiChunkType.Header:
					throw new InvalidOperationException("Multiple header chunks are not allowed.");
				}
				offset += (int)chunk.ChunkLength;
			}
			if (Format != 1)
				throw new InvalidOperationException($"Midi format {Format} is unsupported.");
			if (TrackCount != Tracks.Count)
				throw new InvalidOperationException("Header track count did not match tracks chunks.");
			if ((TicksPerBeat & 0x8000) != 0)
				throw new InvalidOperationException("SMPTE time division is unsupported.");
		}

		private void LoadHeaderData(byte[] data)
		{
			if (data.Length < 6)
				throw new InvalidOperationException("Header length must be at least 6 bytes.");
			Format = BitConverter.ToUInt16(data.Take(2).Reverse().ToArray(), 0);
			TrackCount = BitConverter.ToUInt16(data.Skip(2).Take(2).Reverse().ToArray(), 0);
			TicksPerBeat = BitConverter.ToUInt16(data.Skip(4).Take(2).Reverse().ToArray(), 0);
		}
	}
}
