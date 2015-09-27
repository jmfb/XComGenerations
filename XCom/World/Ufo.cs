using System;
using XCom.Data;

namespace XCom.World
{
	public class Ufo
	{
		public UfoType UfoType { get; set; }
		public UfoStatus Status { get; set; }
		public int Number { get; set; }
		public AlienType AlienType { get; set; }
		public AlienMissionType Mission { get; set; }
		public RegionType Region { get; set; }
		public Location Location { get; set; }
		public Location Destination { get; set; }
		public bool IsDetected { get; set; }
		public bool NotifiedDetection { get; set; }
		public bool HyperWaveTransmissionsDecoded { get; set; }
		public double Speed { get; set; }
		public double DistanceError { get; set; }

		public static Ufo Create(
			UfoType ufoType,
			UfoStatus status,
			AlienType alienType,
			AlienMissionType mission,
			RegionType region)
		{
			var ufo = new Ufo
			{
				UfoType = ufoType,
				Status = status,
				Number = GameState.Current.Data.NextUfoNumber++,
				AlienType = alienType,
				Mission = mission,
				Region = region
			};
			GameState.Current.Data.Ufos.Add(ufo);
			return ufo;
		}

		public string Altitude => "VERY LOW"; //TODO: something with altitudes I guess
		public string Heading => "NORTH WEST";
		public string Name => $"UFO-{Number}";
		public WorldObjectType WorldObjectType =>
			Status == UfoStatus.Flying ? WorldObjectType.Ufo :
			Status == UfoStatus.Landed ? WorldObjectType.LandingSite :
			WorldObjectType.CrashSite;

		//TODO: calculate heading based on Location/Destination

		public void Accelerate(long milliseconds)
		{
			var metadata = UfoType.Metadata();
			var maxSpeed = metadata.MaximumSpeed;
			if (Speed >= maxSpeed)
				return;
			const int ufoAcceleration = 10;
			var speedIncrease = (ufoAcceleration * milliseconds) / 1000.0;
			Speed = Math.Min(maxSpeed, Speed + speedIncrease);
		}

		public int Distance(long milliseconds)
		{
			const double earthCircumferenceInNauticalMiles = 21639;
			const double nauticalMilesPerEightDegree = earthCircumferenceInNauticalMiles / Trigonometry.EighthDegreesCount;
			const double millisecondsPerHour = 1000 * 60 * 60;
			var distanceInNauticalMiles = (Speed * milliseconds) / millisecondsPerHour;
			var distanceInEighthDegrees = distanceInNauticalMiles / nauticalMilesPerEightDegree + DistanceError;
			var integerDistanceInEighthDegrees = (int)distanceInEighthDegrees;
			DistanceError = distanceInEighthDegrees - integerDistanceInEighthDegrees;
			return integerDistanceInEighthDegrees;
		}
	}
}
