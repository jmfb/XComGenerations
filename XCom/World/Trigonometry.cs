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
		public const EighthDegrees EighthDegreesCount = degreesCount * 8;
		private const EighthDegrees halfEighthDegreesCount = EighthDegreesCount / 2;
		public const double RadiansPerEighthDegree = Math.PI / halfEighthDegreesCount;
		private const double tolerance = 0.1e-6;
	
		public class SphereTerrain
		{
			public TerrainType TerrainType { private get; set; }
			public SphereCoordinate[] Vertices { private get; set; }

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
			var vertices = terrain.Vertices
				.Select(vertex => CalculateSphereCoordinate(vertex.X, vertex.Y, longitudeOffset, pitch))
				.ToArray();
			var hiddenPoints = vertices.Count(vertex => vertex.Z < 0);
			switch (hiddenPoints)
			{
			case 1:
				vertices = UnwrapTriangleTip(vertices);
				break;
			case 2:
				vertices = UnwrapTriangleBase(vertices);
				break;
			}
			return new SphereTerrain
			{
				TerrainType = terrain.TerrainType,
				Vertices = vertices
			};
		}

		private static SphereCoordinate[] UnwrapTriangleTip(SphereCoordinate[] vertices)
		{
			var orderedVertices = vertices.OrderBy(vertex => vertex.Z).ToArray();
			var hiddenVertex = orderedVertices[0];
			var vertex1 = orderedVertices[1];
			var vertex2 = orderedVertices[2];
			var intersection1 = ArcSphereIntersection(vertex1, hiddenVertex);
			var intersection2 = ArcSphereIntersection(vertex2, hiddenVertex);
			var unwrappedVertex = LineIntersection(
				vertex1,
				intersection1,
				vertex2,
				intersection2);
			//TODO: Figure out flaw in calculation causing line intersections to not be found.
			return unwrappedVertex == null ?
				vertices :
				new[] { vertex1, vertex2, unwrappedVertex };
		}

		private static SphereCoordinate[] UnwrapTriangleBase(SphereCoordinate[] vertices)
		{
			var orderedVertices = vertices.OrderBy(vertex => vertex.Z).ToArray();
			var hiddenVertex1 = orderedVertices[0];
			var hiddenVertex2 = orderedVertices[1];
			var vertex1 = orderedVertices[2];
			var intersection1 = ArcSphereIntersection(vertex1, hiddenVertex1);
			var intersection2 = ArcSphereIntersection(vertex1, hiddenVertex2);
			//TODO: extend these points a little to cover arc of sphere
			return new[] { vertex1, intersection1, intersection2 };
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
			return cosineTable[Math.Abs(eighthDegrees) % EighthDegreesCount];
		}

		private static Fractional Sine(EighthDegrees eighthDegrees)
		{
			return Math.Sign(eighthDegrees) * sineTable[Math.Abs(eighthDegrees) % EighthDegreesCount];
		}

		private static Fractional Multiply(Fractional value1, Fractional value2)
		{
			return (value1 * value2) >> fractionalPower;
		}

		public static EighthDegrees AddEighthDegrees(EighthDegrees value1, EighthDegrees value2)
		{
			return (value1 + value2 + EighthDegreesCount) % EighthDegreesCount;
		}

		private static Fractional[] CalculateCosineTable()
		{
			return Enumerable.Range(0, EighthDegreesCount)
				.Select(eighthDegrees => (Fractional)(fractionalCount * Math.Cos(eighthDegrees * RadiansPerEighthDegree)))
				.ToArray();
		}

		private static Fractional[] CalculateSineTable()
		{
			return Enumerable.Range(0, EighthDegreesCount)
				.Select(eighthDegrees => (Fractional)(fractionalCount * Math.Sin(eighthDegrees * RadiansPerEighthDegree)))
				.ToArray();
		}

		private static readonly Fractional[] cosineTable = CalculateCosineTable();
		private static readonly Fractional[] sineTable = CalculateSineTable();

		//TODO: Move/refactor all of the code below (ported from previous incarnation of C++ geoscape CMathUtility)

		private static void CrossProduct(double x1, double y1, double z1, double x2, double y2, double z2, out double x, out double y, out double z)
		{
			x = y1 * z2 - z1 * y2;
			y = z1 * x2 - x1 * z2;
			z = x1 * y2 - y1 * x2;
		}

		private static double DotProduct(double x1, double y1, double z1, double x2, double y2, double z2)
		{
			return x1 * x2 + y1 * y2 + z1 * z2;
		}

		private static void MidPoint(double x1, double y1, double z1, double x2, double y2, double z2, out double x, out double y, out double z)
		{
			x = (x2 - x1) / 2.0 + x1;
			y = (y2 - y1) / 2.0 + y1;
			z = (z2 - z1) / 2.0 + z1;
		}

		private static double Distance(double x1, double y1, double z1, double x2, double y2, double z2)
		{
			var dx = x2 - x1;
			var dy = y2 - y1;
			var dz = z2 - z1;
			return Math.Sqrt(dx * dx + dy * dy + dz * dz);
		}

		private static bool IsNegative(double x)
		{
			return x < -tolerance;
		}

		private static bool AreEqual(double value1, double value2)
		{
			return Math.Abs(value2 - value1) < tolerance;
		}

		private static double QuadraticEquation(double a, double b, double c)
		{
			var numerator = b * b - 4.0 * a * c;
			if (IsNegative(numerator))
				return 0.0;
			return (-b + Math.Sqrt(numerator)) / (2.0 * a);
		}

		private static void ArcSphereIntersection(double x1, double y1, double z1, double x2, double y2, double z2, out double x, out double y)
		{
			//Equation of a plane: ax + by + cz + d = 0

			//normal = A cross B = [a,b,c]
			double a, b, c;
			CrossProduct(x1, y1, z1, x2, y2, z2, out a, out b, out c);
	
			//A dot normal = -d
			var d = DotProduct(x1, y1, z1, a, b, c);
	
			//solving for x = e + fy
			var e = -d / a;
			var f = -b / a;
	
			//Intersection with unit cirlce (x^2 + y^2 = 1), x = sqrt(1 - y^2)
			//  substitution yields: (f^2 + 1)y^2 + 2efy + (e^2 + 1) = 0
			y = QuadraticEquation(f * f + 1.0, 2.0 * e * f, e * e - 1.0);
	
			//Backsubstitute y
			x = e + f * y;

			//Since there are two solutions (x,y) and (-x,-y), choose the solution that
			//yields the shortest arc (distance from mid(A,B) <= 1.0)
			double mx, my, mz;
			MidPoint(x1, y1, z1, x2, y2, z2, out mx, out my, out mz);
			if (Distance(x, y, 0, mx, my, mz) <= 1.0)
				return;
			x = -x;
			y = -y;
		}

		private static double FractionalToDouble(Fractional value) => value / (double)fractionalCount;
		private static Fractional DoubleToFractional(double value) => (Fractional)(value * fractionalCount);

		private static SphereCoordinate ArcSphereIntersection(SphereCoordinate p1, SphereCoordinate p2)
		{
			double x, y;
			ArcSphereIntersection(
				FractionalToDouble(p1.X),
				FractionalToDouble(p1.Y),
				FractionalToDouble(p1.Z),
				FractionalToDouble(p2.X),
				FractionalToDouble(p2.Y),
				FractionalToDouble(p2.Z),
				out x,
				out y);
			return new SphereCoordinate
			{
				X = DoubleToFractional(x),
				Y = DoubleToFractional(y),
				Z = 0
			};
		}

		//Determine the slope and intercept of a line (tests for vertical lines)
		private static void LineEquation(
			double x1, double y1,       //First point of line
			double x2, double y2,       //Second point of line
			out double m, out double b,       //Output variables for slope(m) and intercept(b)
			out bool vertical, out double x)  //Output variable for vertical lines
		{
			//Vertical line
			if (AreEqual(x1, x2))
			{
				m = 0;
				b = 0;
				vertical = true;
				x = x1;
			}
			//Horizontal line
			else if (AreEqual(y1, y2))
			{
				m = 0.0;
				b = y1;
				vertical = false;
				x = 0;
			}
			//Regular line
			else
			{
				m = (y2 - y1) / (x2 - x1);
				b = y1 - x1 * m;
				vertical = false;
				x = 0;
			}
		}

		private static void Swap<T>(ref T value1, ref T value2)
		{
			var temp = value1;
			value1 = value2;
			value2 = temp;
		}

		//Determine if two number sequences overlap, and if so what range
		private static bool SequenceOverlap(
			double x1, double x2,   //Unordered first sequence
			double y1, double y2,   //Unordered second sequence
			out double c1, out double c2) //Ordered common sequence
		{
			//Order the sequences
			var a1 = x1 < x2 ? x1 : x2;
			var a2 = x1 < x2 ? x2 : x1;
			var b1 = y1 < y2 ? y1 : y2;
			var b2 = y1 < y2 ? y2 : y1;

			//Determine which sequence is left-most
			if (b1 < a1)
			{
				Swap(ref a1, ref b1);
				Swap(ref a2, ref b2);
			}

			//Determine the common range
			c1 = b1;
			c2 = (b2 < a2) ? b2 : a2;

			//Return whether the sequences overlapped
			return b1 <= a2;
		}

		//Unordered range test, takes into account tolerance for floating point error
		private static bool BetweenEx(
			double x1, double x2,   //Unordered Range
			double val)             //Value to test
		{
			const double toler = 0.1;
			if (x1 < x2)
				return val >= (x1 - toler) && val <= (x2 + toler);
			return val >= (x2 - toler) && val <= (x1 + toler);
		}

		//Determines if two lines segments intersect, and if so where
		private static bool LineIntersection(
			double x1, double y1,   //First point of first line
			double x2, double y2,   //Second point of first line
			double x3, double y3,   //First point of second line
			double x4, double y4,   //Second point of second line
			out double x, out double y)   //Intersection point, if any
		{
			var intersect = false;
			x = 0;
			y = 0;

			//Determine the equation for the first line
			bool vertical1;
			double m1;
			double b1;
			double c1;
			LineEquation(x1, y1, x2, y2, out m1, out b1, out vertical1, out c1);

			//Determine the equation for the second line
			bool vertical2;
			double m2;
			double b2;
			double c2;
			LineEquation(x3, y3, x4, y4, out m2, out b2, out vertical2, out c2);

			//Two vertical lines
			if (vertical1 && vertical2)
			{
				double temp;
				intersect = AreEqual(c1, c2) && SequenceOverlap(y1, y2, y3, y4, out y, out temp);
				x = c1;
			}
			//A vertical line and a non-vertical line
			else if (vertical1 || vertical2)
			{
				x = vertical1 ? c1 : c2;
				y = vertical1 ? m2 * x + b2 : m1 * x + b1;
				intersect = BetweenEx(y1, y2, y) && BetweenEx(y3, y4, y) &&
					(vertical1 ? BetweenEx(x3, x4, x) : BetweenEx(x1, x2, x));
			}
			//Two lines with the same equation
			else if (AreEqual(m1, m2) && AreEqual(b1, b2))
			{
				double temp;
				intersect = SequenceOverlap(x1, x2, x3, x4, out x, out temp);
				y = m1 * x + b1;
			}
			//Two lines with different slopes
			else if (!AreEqual(m1, m2))
			{
				x = (b2 - b1) / (m1 - m2);
				y = m1 * x + b1;
				intersect = BetweenEx(y1, y2, y) && BetweenEx(y3, y4, y) &&
					BetweenEx(x1, x2, x) && BetweenEx(x3, x4, x);
			}

			return intersect;
		}

		private static SphereCoordinate LineIntersection(
			SphereCoordinate line1Point1,
			SphereCoordinate line1Point2,
			SphereCoordinate line2Point1,
			SphereCoordinate line2Point2)
		{
			double x, y;
			if (!LineIntersection(
				FractionalToDouble(line1Point1.X),
				FractionalToDouble(line1Point1.Y),
				FractionalToDouble(line1Point2.X),
				FractionalToDouble(line1Point2.Y),
				FractionalToDouble(line2Point1.X),
				FractionalToDouble(line2Point1.Y),
				FractionalToDouble(line2Point2.X),
				FractionalToDouble(line2Point2.Y),
				out x,
				out y))
				return null;
			return new SphereCoordinate
			{
				X = DoubleToFractional(x),
				Y = DoubleToFractional(y),
				Z = 0
			};
		}
	}
}
