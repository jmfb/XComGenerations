using System;
using XCom.Controls;
using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;

namespace XCom.Screens
{
	public class TopicView : Screen
	{
		private readonly TopicCategory? category;
		private readonly TopicType topic;

		public TopicView(TopicCategory? category, TopicType topic)
		{
			this.category = category;
			this.topic = topic;
			var metadata = topic.Metadata();
			if (metadata.Background != null)
				AddControl(new Background(metadata.Background, 4));
			AddTopicControls();
			AddControl(new Button(5, 5, 30, 14, "OK", metadata.Scheme, Font.Normal, OnOk));
			AddControl(new Button(5, 40, 30, 14, "<<", metadata.Scheme, Font.Normal, OnPrevious));
			AddControl(new Button(5, 75, 30, 14, ">>", metadata.Scheme, Font.Normal, OnNext));
		}

		private void OnOk() => GameState.Current.SetScreen(category == null ? (Screen)Geoscape : new TopicList(category.Value));
		private void OnPrevious() => GameState.Current.SetScreen(new TopicView(category, GameState.Current.Data.GetPreviousTopic(topic)));
		private void OnNext() => GameState.Current.SetScreen(new TopicView(category, GameState.Current.Data.GetNextTopic(topic)));

		private void AddTopicControls()
		{
			var metadata = topic.Metadata();
			if (metadata.Craft != null)
				AddCraftControls(metadata.Craft.Value);
			else if (metadata.CraftWeapon != null)
				AddArmamentControls(metadata.CraftWeapon.Value);
			//TODO: other types
		}

		private void AddCraftControls(CraftType craft)
		{
			var metadata = craft.Metadata();
			AddControl(new Overlay(metadata.Overlay));
			AddControl(new Label(24, 5, metadata.Name, Font.Large, ColorScheme.LightPurple));
			var nextDescriptionTop = 40;
			foreach (var descriptionLine in metadata.DescriptionLines)
			{
				var top = nextDescriptionTop;
				nextDescriptionTop += 8;
				AddControl(new Label(top, 5, descriptionLine, Font.Normal, ColorScheme.LightPurple));
			}

			var left = metadata.ShowStatsOnBottom ? 5 : 160;
			var nextStatTop = metadata.ShowStatsOnBottom ? 110 : 5;
			var stats = new[]
			{
				Tuple.Create("MAXIMUM SPEED>", metadata.Speed),
				Tuple.Create("ACCELERATION>", metadata.Acceleration),
				Tuple.Create("FUEL CAPACITY>", metadata.Fuel),
				Tuple.Create("WEAPON PODS>", metadata.WeaponCount),
				Tuple.Create("CARGO SPACE>", metadata.Space),
				Tuple.Create("HWP CAPACITY>", metadata.HwpCount)
			};
			foreach (var stat in stats)
			{
				var top = nextStatTop;
				nextStatTop += 8;
				AddControl(new Label(top, left, stat.Item1, Font.Normal, ColorScheme.LightPurple));
				AddControl(new Label(top, left + Font.Normal.MeasureString(stat.Item1) - 1, stat.Item2.FormatNumber(), Font.Normal, ColorScheme.LightAqua));
			}
		}

		private void AddArmamentControls(CraftWeaponType craftWeapon)
		{
			var metadata = craftWeapon.Metadata();
			AddControl(new Overlay(metadata.Overlay, 4));
			AddControl(new Label(24, 5, metadata.Name, Font.Large, ColorScheme.White));
			
			var nextTop = 95;
			var stats = new[]
			{
				Tuple.Create("Damage", metadata.Damage.FormatNumber()),
				Tuple.Create("Range", metadata.Range.FormatNumber() + " km"),
				Tuple.Create("Accuracy", metadata.Accuracy.FormatNumber() + "%"),
				Tuple.Create("Re-load time", metadata.ReloadTime.FormatNumber() + "s")
			};
			foreach (var stat in stats)
			{
				var top = nextTop;
				nextTop += 16;
				AddControl(new ExtendedLabel(top, 5, 135, stat.Item1, Font.Large, ColorScheme.White));
				AddControl(new Label(top, 140, stat.Item2, Font.Large, ColorScheme.LightBlue));
			}
		}
	}
}
