using System;
using System.Linq;
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
				AddControl(new Background(metadata.Background, metadata.BackgroundPalette));
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
			else if (metadata.Hwp != null)
				AddHeavyWeaponsPlatformControls(metadata.Hwp.Value);
			else if (metadata.Armor != null)
				AddArmorControls(metadata.Armor.Value);
			else if (metadata.Weapon != null)
				AddWeaponControls(metadata.Weapon.Value);
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

		private void AddHeavyWeaponsPlatformControls(HwpType hwp)
		{
			var metadata = hwp.Metadata();
			AddControl(new Label(24, 5, metadata.Name, Font.Large, ColorScheme.LightAqua));

			var nextTop = 45;
			var stats = new[]
			{
				Tuple.Create("TIME UNITS", metadata.TimeUnits.FormatNumber()),
				Tuple.Create("HEALTH", metadata.Health.FormatNumber()),
				Tuple.Create("Front Armor", metadata.FrontArmor.FormatNumber()),
				Tuple.Create("Left Armor", metadata.LeftArmor.FormatNumber()),
				Tuple.Create("Right Armor", metadata.RightArmor.FormatNumber()),
				Tuple.Create("Rear Armor", metadata.RearArmor.FormatNumber()),
				Tuple.Create("Under Armor", metadata.UnderArmor.FormatNumber()),
				Tuple.Create("Weapon", metadata.DamageType.Metadata().Name),
				Tuple.Create("Weapon Power", metadata.Damage.FormatNumber()),
				Tuple.Create("Ammunition", metadata.Ammunition?.Metadata().Name),
				Tuple.Create("Rounds", metadata.Rounds == 0 ? null : metadata.Rounds.FormatNumber())
			};
			foreach (var stat in stats.Where(stat => stat.Item2 != null))
			{
				var top = nextTop;
				nextTop += 8;
				AddControl(new ExtendedLabel(top, 10, 175, stat.Item1, Font.Normal, ColorScheme.LightAqua));
				AddControl(new Label(top, 185, stat.Item2, Font.Normal, ColorScheme.LightAqua));
			}
			nextTop += 2;
			foreach (var descriptionLine in metadata.DescriptionLines)
			{
				var top = nextTop;
				nextTop += 8;
				AddControl(new Label(top, 10, descriptionLine, Font.Normal, ColorScheme.LightPurple));
			}
		}

		private void AddArmorControls(ArmorType armor)
		{
			var metadata = armor.Metadata();
			AddControl(new Overlay(metadata.Overlay, 4));
			AddControl(new Label(24, 5, metadata.Name, Font.Large, ColorScheme.White));

			var nextTop = 70;
			var stats = new[]
			{
				Tuple.Create("Front Armor", metadata.FrontArmor),
				Tuple.Create("Left Armor", metadata.LeftArmor),
				Tuple.Create("Right Armor", metadata.RightArmor),
				Tuple.Create("Rear Armor", metadata.RearArmor),
				Tuple.Create("Under Armor", metadata.UnderArmor)
			};
			foreach (var stat in stats)
			{
				var top = nextTop;
				nextTop += 8;
				AddControl(new ExtendedLabel(top, 150, 125, stat.Item1, Font.Normal, ColorScheme.White));
				AddControl(new Label(top, 275, stat.Item2.FormatNumber(), Font.Normal, ColorScheme.LightBlue));
			}
		}

		private void AddWeaponControls(ItemType weapon)
		{
			var metadata = weapon.Metadata();
			AddControl(new Item(3, 157, metadata.Image));
			AddControl(new Label(24, 5, metadata.Name, Font.Large, ColorScheme.White));
			//TODO: center overlay
			//TODO: ammo stuff, shot type stuff, description
		}
	}
}
