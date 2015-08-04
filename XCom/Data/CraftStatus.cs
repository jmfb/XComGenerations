using System;

namespace XCom.Data
{
	public enum CraftStatus
	{
		Ready,
		Out,
		Repairs,
		Refuelling,
		Rearming
	}

	public static class CraftStatusExtensions
	{
		public static string Name(this CraftStatus craftStatus)
		{
			switch (craftStatus)
			{
			case CraftStatus.Ready:
				return "READY";
			case CraftStatus.Out:
				return "OUT";
			case CraftStatus.Repairs:
				return "REPAIRS";
			case CraftStatus.Refuelling:
				return "REFUELLING";
			case CraftStatus.Rearming:
				return "REARMING";
			}
			throw new InvalidOperationException("Invalid craft status.");
		}
	}
}
