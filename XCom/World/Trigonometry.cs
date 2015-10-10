using System;
using System.Drawing;
using System.Linq;

namespace XCom.World
{
	public static class Trigonometry
	{
		private const int degreesCount = 360;
		public const int EighthDegreesCount = degreesCount * 8;
		private const int halfEighthDegreesCount = EighthDegreesCount / 2;
		private const double radiansPerEighthDegree = Math.PI / halfEighthDegreesCount;
		private const double tolerance = 0.1e-6;
	
		public static int AddEighthDegrees(int value1, int value2)
		{
			return (value1 + value2 + 2 * EighthDegreesCount) % EighthDegreesCount;
		}

		//TODO: Move/refactor all of the code below (ported from previous incarnation of C++ geoscape CMathUtility)

		private static bool IsNegative(double x)
		{
			return x < -tolerance;
		}

		private static bool AreEqual(double value1, double value2)
		{
			return Math.Abs(value2 - value1) < tolerance;
		}

		private static double[] QuadraticEquationBothSolutions(double a, double b, double c)
		{
			var numerator = b * b - 4.0 * a * c;
			if (IsNegative(numerator))
				return new[] { 0.0, 0.0 };
			return new[]
			{
				(-b + Math.Sqrt(numerator)) / (2.0 * a),
				(-b - Math.Sqrt(numerator)) / (2.0 * a)
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

		public static Point? LocationToScreen(Location location)
		{
			var rollRadians = GameState.Current.Data.LongitudeOffset * radiansPerEighthDegree;
			var pitchRadians = GameState.Current.Data.Pitch * radiansPerEighthDegree;
			var latitude = location.Latitude * radiansPerEighthDegree;
			var longitude = location.Longitude * radiansPerEighthDegree;

			var unitZ = Math.Sin(latitude) * Math.Sin(pitchRadians) +
				Math.Cos(longitude + rollRadians) * Math.Cos(latitude) * Math.Cos(pitchRadians);
			if (unitZ < 0)
				return null;

			var unitX = Math.Sin(longitude + rollRadians) * Math.Cos(latitude);
			var unitY = Math.Sin(latitude) * Math.Cos(pitchRadians) -
				Math.Cos(longitude + rollRadians) * Math.Cos(latitude) * Math.Sin(pitchRadians);

			var x = (int)(unitX * WorldView.Radius) + WorldView.CenterX;
			var y = (int)(unitY * WorldView.Radius) + WorldView.CenterY;
			if (x < 0 || x >= WorldView.CenterX * 2 || y < 0 || y >= WorldView.CenterY * 2)
				return null;
			return new Point { X = x, Y = y };
		}

		public static bool HitTestCoordinate(Location clickLocation, Location location)
		{
			var clickPoint = LocationToScreen(clickLocation);
			if (clickPoint == null)
				return false;
			var point = LocationToScreen(location);
			if (point == null)
				return false;
			var dx = point.Value.X - clickPoint.Value.X;
			var dy = point.Value.Y - clickPoint.Value.Y;
			var distanceSquared = dx * dx + dy * dy;
			var distance = Math.Sqrt(distanceSquared);
			const int allowedDistanceForHit = 3;
			return distance <= allowedDistanceForHit;
		}

		public static Location ScreenToLocation(int row, int column)
		{
			var x = (double)(column - WorldView.CenterX);
			var y = (double)(row - WorldView.CenterY);
			var r = (double)WorldView.Radius;
			var z2 = r * r - x * x - y * y;
			if (z2 < 0)
				return null;
			var z = Math.Sqrt(z2);

			var pitchRadians = GameState.Current.Data.Pitch * radiansPerEighthDegree;
			var rollRadians = GameState.Current.Data.LongitudeOffset * radiansPerEighthDegree;

			var unitX = x / r;
			var unitY = y / r;
			var unitZ = z / r;

			var rotatedX = unitX;
			var rotatedY = unitY * Math.Cos(pitchRadians) + unitZ * Math.Sin(pitchRadians);
			var rotatedZ = unitZ * Math.Cos(pitchRadians) - unitY * Math.Sin(pitchRadians);

			var latitude = Math.Asin(rotatedY);
			var longitude = Math.Atan2(rotatedX, rotatedZ) - rollRadians;

			var latitudeEighthDegrees = (int)(latitude / radiansPerEighthDegree);
			var longitudeEighthDegrees = (int)(longitude / radiansPerEighthDegree);

			return new Location
			{
				Longitude = AddEighthDegrees(longitudeEighthDegrees, 0),
				Latitude = latitudeEighthDegrees
			};
		}

		public static Location MoveLocation(Location source, Location destination, int distance)
		{
			var xr = destination.Longitude < source.Longitude ? destination.Longitude + EighthDegreesCount : destination.Longitude;
			var xl = destination.Longitude > source.Longitude ? destination.Longitude - EighthDegreesCount : destination.Longitude;
			var dxr = xr - source.Longitude;
			var dxl = xl - source.Longitude;
			var dy = destination.Latitude - source.Latitude;
			var maxDistanceToRight = Math.Sqrt(dxr * dxr + dy * dy);
			var maxDistanceToLeft = Math.Sqrt(dxl * dxl + dy * dy);
			var destinationLongitude = maxDistanceToLeft < maxDistanceToRight ? xl : xr;
			var dx = maxDistanceToLeft < maxDistanceToRight ? dxl : dxr;
			var maxDistance = Math.Min(maxDistanceToLeft, maxDistanceToRight);

			if (distance >= maxDistance)
				return new Location
				{
					Longitude = destination.Longitude,
					Latitude = destination.Latitude
				};

			double m, b, x;
			bool vertical;
			LineEquation(source.Longitude, source.Latitude, destinationLongitude, destination.Latitude, out m, out b, out vertical, out x);
			if (vertical)
				return new Location
				{
					Longitude = source.Longitude,
					Latitude = source.Latitude + Math.Sign(dy) * distance
				};

			var c = b - source.Latitude;
			var longitudes = QuadraticEquationBothSolutions(
				m * m + 1,
				2 * m * c - 2 * source.Longitude,
				c * c + source.Longitude * source.Longitude - distance * distance);
			var longitude = dx < 0 ? longitudes.Min() : longitudes.Max();
			var latitude = m * longitude + b;
			return new Location
			{
				Longitude = AddEighthDegrees((int)longitude, 0),
				Latitude = (int)latitude
			};
		}
	}
}
