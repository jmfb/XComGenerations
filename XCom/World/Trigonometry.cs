using System;
using System.Drawing;
using System.Linq;
using Fractional = System.Int32;
using EighthDegrees = System.Int32;
// ReSharper disable BuiltInTypeReferenceStyle -- Using int aliases to clarify argument/result types.

namespace XCom.World
{
	public static class Trigonometry
	{
		private const int fractionalPower = 10;
		private const Fractional fractionalCount = 1 << fractionalPower;
		private const int degreesCount = 360;
		private const EighthDegrees eighthDegreesCount = degreesCount * 8;
		private const EighthDegrees halfEighthDegreesCount = eighthDegreesCount / 2;
		private const double radiansPerEighthDegree = Math.PI / halfEighthDegreesCount;
	
		public class SphereTerrain
		{
			public TerrainType TerrainType { private get; set; }
			public SphereCoordinate[] Vertices { private get; set; }

			//TODO: Handle case of partially front-facing (at least 1 vertex with Z >= 0)
			public bool IsFrontFacing => Vertices.All(vertex => vertex.Z >= 0);

			public Terrain Scale(int radius, int centerX, int centerY)
			{
				return new Terrain
				{
					TerrainType = TerrainType,
					Vertices = Vertices
						.Select(vertex => new Point
						{
							X = Multiply(radius, vertex.X) + centerX,
							Y = Multiply(radius, vertex.Y) + centerY
						}).ToArray()
					
				};
			}
		}

		public static SphereTerrain MapTerrainToSphere(Terrain terrain, EighthDegrees longitudeOffset, EighthDegrees pitch)
		{
			return new SphereTerrain
			{
				TerrainType = terrain.TerrainType,
				Vertices = terrain.Vertices
					.Select(vertex => CalculateSphereCoordinate(vertex.X, vertex.Y, longitudeOffset, pitch))
					.ToArray()
			};
		}

		public class SphereCoordinate
		{
			public Fractional X { get; set; }
			public Fractional Y { get; set; }
			public Fractional Z { get; set; }
		}

		private static SphereCoordinate CalculateSphereCoordinate(EighthDegrees longitude, EighthDegrees latitude, EighthDegrees longitudeOffset, EighthDegrees pitch)
		{
			return new SphereCoordinate
			{
				X = CalculateSphereX(longitude, longitudeOffset, latitude),
				Y = CalculateSphereY(longitude, longitudeOffset, latitude, pitch),
				Z = CalculateSphereZ(longitude, longitudeOffset, latitude, pitch)
			};
		}

		private static Fractional CalculateSphereX(EighthDegrees longitude, EighthDegrees longitudeOffset, EighthDegrees latitude)
		{
			return Multiply(Sine(longitude + longitudeOffset), Cosine(latitude));
		}

		private static Fractional CalculateSphereY(EighthDegrees longitude, EighthDegrees longitudeOffset, EighthDegrees latitude, EighthDegrees pitch)
		{
			return Multiply(Sine(latitude), Cosine(pitch)) - Multiply(Multiply(Cosine(longitude + longitudeOffset), Cosine(latitude)), Sine(pitch));
		}

		private static Fractional CalculateSphereZ(EighthDegrees longitude, EighthDegrees longitudeOffset, EighthDegrees latitude, EighthDegrees pitch)
		{
			return Multiply(Sine(latitude), Sine(pitch)) + Multiply(Multiply(Cosine(longitude + longitudeOffset), Cosine(latitude)), Cosine(pitch));
		}

		private static Fractional Cosine(EighthDegrees eighthDegrees)
		{
			return cosineTable[Math.Abs(eighthDegrees) % eighthDegreesCount];
		}

		private static Fractional Sine(EighthDegrees eighthDegrees)
		{
			return Math.Sign(eighthDegrees) * sineTable[Math.Abs(eighthDegrees) % eighthDegreesCount];
		}

		private static Fractional Multiply(Fractional value1, Fractional value2)
		{
			return (value1 * value2) >> fractionalPower;
		}

		public static EighthDegrees AddEighthDegrees(EighthDegrees value1, EighthDegrees value2)
		{
			return (value1 + value2 + eighthDegreesCount) % eighthDegreesCount;
		}

		private static Fractional[] CalculateCosineTable()
		{
			return Enumerable.Range(0, eighthDegreesCount)
				.Select(eighthDegrees => (Fractional)(fractionalCount * Math.Cos(eighthDegrees * radiansPerEighthDegree)))
				.ToArray();
		}

		private static Fractional[] CalculateSineTable()
		{
			return Enumerable.Range(0, eighthDegreesCount)
				.Select(eighthDegrees => (Fractional)(fractionalCount * Math.Sin(eighthDegrees * radiansPerEighthDegree)))
				.ToArray();
		}

		private static readonly Fractional[] cosineTable = CalculateCosineTable();
		private static readonly Fractional[] sineTable = CalculateSineTable();
	}
}
