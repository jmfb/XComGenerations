using XCom.Content.Images.Ranks;
using XCom.Graphics;

namespace XCom.Data;

public enum Rank
{
	Rookie,
	Squaddie,
	Sergeant,
	Captain,
	Colonel,
	Commander,
}

public static class RankExtensions
{
	public static Image Image(this Rank rank)
	{
		return images[rank];
	}

	private static readonly Image rookie = new(Ranks.Rookie);
	private static readonly Image squaddie = new(Ranks.Squaddie);
	private static readonly Image sergeant = new(Ranks.Sergeant);
	private static readonly Image captain = new(Ranks.Captain);
	private static readonly Image colonel = new(Ranks.Colonel);
	private static readonly Image commander = new(Ranks.Commander);

	private static readonly Dictionary<Rank, Image> images = new()
	{
		{ Rank.Rookie, rookie },
		{ Rank.Squaddie, squaddie },
		{ Rank.Sergeant, sergeant },
		{ Rank.Captain, captain },
		{ Rank.Colonel, colonel },
		{ Rank.Commander, commander },
	};
}
