using System.Collections.Generic;
using XCom.Content.Images.Ranks;
using XCom.Graphics;

namespace XCom.Data
{
	public enum Rank
	{
		Rookie,
		Squaddie,
		Sergeant,
		Captain,
		Colonel,
		Commander
	}

	public static class RankExtensions
	{
		public static Image Image(this Rank rank)
		{
			return images[rank];
		}

		private static readonly Image rookie = new Image(Ranks.Rookie);
		private static readonly Image squaddie = new Image(Ranks.Squaddie);
		private static readonly Image sergeant = new Image(Ranks.Sergeant);
		private static readonly Image captain = new Image(Ranks.Captain);
		private static readonly Image colonel = new Image(Ranks.Colonel);
		private static readonly Image commander = new Image(Ranks.Commander);
		
		private static readonly Dictionary<Rank, Image> images = new Dictionary<Rank,Image>
 		{
			{ Rank.Rookie, rookie },
			{ Rank.Squaddie, squaddie },
			{ Rank.Sergeant, sergeant },
			{ Rank.Captain, captain },
			{ Rank.Colonel, colonel },
			{ Rank.Commander, commander }
		};
	}
}
