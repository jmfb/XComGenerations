﻿using System.Linq;
using XCom.Graphics;

namespace XCom.Battlescape.Tiles
{
	public class Animation
	{
		private readonly byte[][] images;

		private Animation(ImageGroup imageGroup, int index, int count)
		{
			images = imageGroup.Images.Skip(index).Take(count).ToArray();
		}

		public void Animate(GraphicsBuffer buffer, int topRow, int leftColumn, int frame)
		{
			buffer.DrawItem(topRow, leftColumn, images[frame]);
		}

		public int FrameCount => images.Length;

		public static readonly Animation ZombieDeath = new Animation(ImageGroup.Zombie, 72, 18);
	}
}
