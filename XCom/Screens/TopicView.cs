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
			else if (metadata.Grenade != null)
				AddGrenadeControls(metadata.Grenade.Value);
			else if (metadata.Equipment != null)
				AddEquipmentControls(metadata.Equipment.Value);
			else if (metadata.Ammunition != null)
				AddAmmunitionControls(metadata.Ammunition.Value);
			else if (metadata.Facility != null)
				AddFacilityControls(metadata.Facility.Value);
			else if (metadata.Alien != null)
				AddAlienControls(metadata.Alien.Value);
			else if (metadata.AlienResearch != null)
				AddAlienResearchControls(metadata.AlienResearch.Value);
			else if (metadata.UfoComponent != null)
				AddUfoComponentControls(metadata.UfoComponent.Value);
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
				Tuple.Create("Accuracy", metadata.Accuracy.FormatNumber() + "\t%"),
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

		private void AddWeaponControls(WeaponType weapon)
		{
			var metadata = weapon.Metadata();
			AddControl(new Item(4 + 8 * (3 - metadata.Height), 158 + 8 * (2 - metadata.Width), metadata.Image));
			AddControl(new Label(24, 5, metadata.Name, Font.Large, ColorScheme.White));

			AddControl(new Label(7, 224, "DAMAGE", Font.Normal, ColorScheme.White));
			AddControl(new Label(7, 285, "AMMO", Font.Normal, ColorScheme.White));

			var nextTop = 24;
			var ammoLeft = Label.CenterOf(195, 90);
			var laserWeapon = EnumEx.GetValues<LaserWeaponType>()
				.Where(laserWeaponType => laserWeaponType.Metadata().Weapon == weapon)
				.Cast<LaserWeaponType?>()
				.SingleOrDefault();
			if (laserWeapon != null)
			{
				AddControl(new Label(nextTop, ammoLeft, DamageType.LaserBeam.Metadata().Name, Font.Normal, ColorScheme.White));
				AddControl(new Label(nextTop + 16, ammoLeft, laserWeapon.Value.Metadata().Damage.FormatNumber(), Font.Large, ColorScheme.Red));
			}
			else
			{
				foreach (var ammunition in metadata.SupportedAmmunition)
				{
					var ammoMetadata = ammunition.Metadata();
					var top = nextTop;
					nextTop += 49;
					AddControl(new Label(top, ammoLeft, ammoMetadata.DamageType.Metadata().Name, Font.Normal, ColorScheme.White));
					AddControl(new Label(top + 16, ammoLeft, ammoMetadata.Damage.FormatNumber(), Font.Large, ColorScheme.Red));
					AddControl(new Item(
						top - 7 + 8 * (3 - ammoMetadata.Height),
						283 + 8 * (2 - ammoMetadata.Width),
						ammoMetadata.Image));
				}
			}

			AddControl(new Label(67, 8, "SHOT TYPE>", Font.Normal, ColorScheme.White));
			AddControl(new Label(67, 80, "ACCURACY>", Font.Normal, ColorScheme.White));
			AddControl(new Label(67, 152, "TU COST>", Font.Normal, ColorScheme.White));

			nextTop = 82;
			foreach (var shot in metadata.Shots)
			{
				var top = nextTop;
				nextTop += 20;
				AddControl(new Label(top, 8, shot.ShotType.Metadata().Name, Font.Large, ColorScheme.White));
				AddControl(new Label(top, 88, $"{shot.Accuracy.FormatNumber()}\t%", Font.Large, ColorScheme.LightBlue));
				AddControl(new Label(top, 144, $"{shot.TimeUnits.FormatNumber()}\t%", Font.Large, ColorScheme.LightBlue));
			}

			nextTop = 138;
			foreach (var descriptionLine in metadata.DescriptionLines)
			{
				var top = nextTop;
				nextTop += 8;
				AddControl(new Label(top, 8, descriptionLine, Font.Normal, ColorScheme.White));
			}
		}

		private void AddGrenadeControls(GrenadeType grenade)
		{
			var metadata = grenade.Metadata();
			AddControl(new Item(4 + 8 * (3 - metadata.Height), 158 + 8 * (2 - metadata.Width), metadata.Image));
			AddControl(new WrappedLabel(24, 5, 150, metadata.Name, Font.Large, ColorScheme.White));

			AddControl(new Label(24, Label.CenterOf(195, 90), metadata.DamageType.Metadata().Name, Font.Normal, ColorScheme.White));
			AddControl(new Label(40, Label.CenterOf(195, 90), metadata.Damage.FormatNumber(), Font.Large, ColorScheme.Red));

			var nextTop = 67;
			foreach (var descriptionLine in metadata.DescriptionLines)
			{
				var top = nextTop;
				nextTop += 8;
				AddControl(new Label(top, 8, descriptionLine, Font.Normal, ColorScheme.White));
			}
		}

		private void AddEquipmentControls(EquipmentType equipment)
		{
			var metadata = equipment.Metadata();
			AddControl(new Item(4 + 8 * (3 - metadata.Height), 158 + 8 * (2 - metadata.Width), metadata.Image));
			AddControl(new WrappedLabel(24, 5, 150, metadata.Name, Font.Large, ColorScheme.White));

			var nextTop = 67;
			foreach (var descriptionLine in metadata.DescriptionLines)
			{
				var top = nextTop;
				nextTop += 8;
				AddControl(new Label(top, 8, descriptionLine, Font.Normal, ColorScheme.White));
			}
		}

		private void AddAmmunitionControls(AmmunitionType ammunition)
		{
			var metadata = ammunition.Metadata();
			AddControl(new Item(4 + 8 * (3 - metadata.Height), 158 + 8 * (2 - metadata.Width), metadata.Image));
			AddControl(new WrappedLabel(24, 5, 150, metadata.Name, Font.Large, ColorScheme.White));

			AddControl(new Label(24, Label.CenterOf(195, 90), metadata.DamageType.Metadata().Name, Font.Normal, ColorScheme.White));
			AddControl(new Label(40, Label.CenterOf(195, 90), metadata.Damage.FormatNumber(), Font.Large, ColorScheme.Red));

			var nextTop = 67;
			foreach (var descriptionLine in metadata.DescriptionLines)
			{
				var top = nextTop;
				nextTop += 8;
				AddControl(new Label(top, 8, descriptionLine, Font.Normal, ColorScheme.White));
			}
		}

		private void AddFacilityControls(FacilityType facility)
		{
			var metadata = facility.Metadata();
			if (metadata.Shape == FacilityShape.Hangar)
			{
				AddControl(new Picture(18, 233, metadata.Image));
			}
			else
			{
				AddControl(new Picture(31, 249, metadata.Shape.BuildingImage()));
				AddControl(new Picture(30 + metadata.RowOffset, 248 + metadata.ColumnOffset, metadata.Image));
			}
			AddControl(new Label(24, 10, metadata.Name, Font.Large, ColorScheme.Blue));

			var nextTop = 40;
			var stats = new[]
			{
				Tuple.Create("Construction Time", $"{metadata.DaysToConstruct} days"),
				Tuple.Create("Construction Cost", $"${metadata.Cost.FormatNumber()}"),
				Tuple.Create("Maintenance Cost", $"${metadata.Maintenance.FormatNumber()}"),
				Tuple.Create("Defense Value", metadata.DefenseValue == 0 ? null : metadata.DefenseValue.FormatNumber()),
				Tuple.Create("Hit Ratio", metadata.HitRatio == 0 ? null : $"{metadata.HitRatio}\t%")
			};
			foreach (var stat in stats.Where(stat => stat.Item2 != null))
			{
				var top = nextTop;
				nextTop += 10;
				AddControl(new ExtendedLabel(top, 10, 140, stat.Item1, Font.Normal, ColorScheme.Blue));
				AddControl(new Label(top, 150, stat.Item2, Font.Normal, ColorScheme.White));
			}

			nextTop = 104;
			foreach (var descriptionLine in metadata.DescriptionLines)
			{
				var top = nextTop;
				nextTop += 8;
				AddControl(new Label(top, 10, descriptionLine, Font.Normal, ColorScheme.Blue));
			}
		}

		private void AddAlienControls(AlienType alien)
		{
			var metadata = alien.Metadata();
			AddControl(new Label(24, 5, metadata.Name, Font.Large, ColorScheme.LightAqua));
			AddControl(new Overlay(metadata.Overlay));
			var nextTop = 40;
			foreach (var descriptionLine in metadata.DescriptionLines)
			{
				var top = nextTop;
				nextTop += 8;
				AddControl(new Label(top, 5, descriptionLine, Font.Normal, ColorScheme.LightPurple));
			}
		}

		private void AddAlienResearchControls(AlienResearchType alienResearch)
		{
			var metadata = alienResearch.Metadata();
			AddControl(new Label(24, 5, metadata.Name, Font.Large, ColorScheme.LightAqua));
			var nextTop = 48;
			foreach (var descriptionLine in metadata.DescriptionLines)
			{
				var top = nextTop;
				nextTop += 8;
				AddControl(new Label(top, 10, descriptionLine, Font.Normal, ColorScheme.LightPurple));
			}
		}

		private void AddUfoComponentControls(UfoComponentType ufoComponent)
		{
			var metadata = ufoComponent.Metadata();
			var title = new WrappedLabel(24, 5, metadata.LabelWidth, metadata.Name, Font.Large, ColorScheme.LightAqua);
			AddControl(title);
			AddControl(new Overlay(metadata.Overlay));
			AddControl(new WrappedLabel(title.Bottom + 2, 5, metadata.LabelWidth, metadata.Description, Font.Normal, ColorScheme.LightPurple));
		}
	}
}
