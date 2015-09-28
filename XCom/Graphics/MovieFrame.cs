using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace XCom.Graphics
{
	public class MovieFrame
	{
		public MovieFrameHeader Header { get; }
		public List<object> Subframes { get; }

		public MovieFrame(byte[] data, int offset)
		{
			Header = data.ReadStruct<MovieFrameHeader>(offset);
			if (Header.FrameType != 0xf1fa)
				throw new InvalidOperationException("expected frame type");
			Subframes = ReadSubframes(data, offset + Marshal.SizeOf(Header)).ToList();
		}

		private IEnumerable<object> ReadSubframes(byte[] data, int offset)
		{
			var nextSubframeOffset = offset;
			for (var index = 0; index < Header.ChunkCount; ++index)
			{
				var subframeOffset = nextSubframeOffset;
				var subframeHeader = data.ReadStruct<SubframeHeader>(subframeOffset);
				nextSubframeOffset += (int)subframeHeader.Size;
				var subframeDataOffset = subframeOffset + Marshal.SizeOf(subframeHeader);
				switch (subframeHeader.SubframeType)
				{
				case SubframeHeader.TypeColor64:
					yield return new SubframeColor64(data, subframeDataOffset);
					break;
				case SubframeHeader.TypeByteRun:
					yield return new MovieSubframeByteRun(data, subframeDataOffset);
					break;
				case SubframeHeader.TypeDelta:
					yield return new MovieSubframeDelta(data, subframeDataOffset);
					break;
				default:
					throw new InvalidOperationException("unsupported subframe type");
				}
			}
		}
	}
}
