using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;

namespace XCom.Graphics
{
	public class Movie : Drawable
	{
		private readonly MovieHeader header;
		private Color[] palette;
		private readonly List<object> frames;
		private readonly byte[,] image = new byte[200, 320];
		private int frameIndex;
		private readonly Stopwatch stopwatch = new Stopwatch();
		private int FrameSpeedInMilliseconds => (int)header.Speed * 20;

		public Movie(byte[] data)
		{
			header = data.ReadStruct<MovieHeader>(0);
			if (header.Height != 200)
				throw new InvalidOperationException("invalid height");
			if (header.Width != 320)
				throw new InvalidOperationException("invalid width");
			if (header.Depth != 8)
				throw new InvalidOperationException("invalid depth");
			frames = ReadFrames(data, Marshal.SizeOf(header)).ToList();
			if (palette == null)
				throw new InvalidOperationException("missing palette");
			ApplyFrame();
			stopwatch.Restart();
		}

		private IEnumerable<object> ReadFrames(byte[] data, int offset)
		{
			var nextFrameOffset = offset;
			for (var index = 0; index < header.FrameCount; ++index)
			{
				var frameOffset = nextFrameOffset;
				var frame = new MovieFrame(data, frameOffset);
				foreach (var subframe in frame.Subframes)
				{
					var subframeColor64 = subframe as SubframeColor64;
					if (subframeColor64 != null)
						palette = subframeColor64.Colors;
					else
						yield return subframe;
				}
				nextFrameOffset += (int)frame.Header.Size;
			}
		}

		public void Render(GraphicsBuffer buffer)
		{
			foreach (var row in Enumerable.Range(0, 200))
			{
				foreach (var column in Enumerable.Range(0, 320))
				{
					var paletteIndex = image[row, column];
					buffer.SetPixel(row, column, palette[paletteIndex]);
				}
			}
		}

		private int MovieDuration => FrameSpeedInMilliseconds * frames.Count + 5000;
		public bool IsOver => stopwatch.ElapsedMilliseconds >= MovieDuration;

		public void OnIdle()
		{
			var nextFrameIndex = stopwatch.ElapsedMilliseconds / FrameSpeedInMilliseconds;
			if (nextFrameIndex == frameIndex)
				return;
			do
			{
				++frameIndex;
				ApplyFrame();
			}
			while (frameIndex < nextFrameIndex);
		}

		private void ApplyFrame()
		{
			if (frameIndex >= frames.Count)
				return;
			(frames[frameIndex] as MovieSubframeByteRun)?.Apply(image);
			(frames[frameIndex] as MovieSubframeDelta)?.Apply(image);
		}
	}
}
