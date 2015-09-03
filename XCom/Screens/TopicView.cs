using XCom.Controls;
using XCom.Data;
using XCom.Fonts;

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
			AddControl(new Button(5, 5, 30, 13, "OK", metadata.Scheme, Font.Normal, OnOk));
			AddControl(new Button(5, 40, 30, 13, "<<", metadata.Scheme, Font.Normal, OnPrevious));
			AddControl(new Button(5, 75, 30, 13, ">>", metadata.Scheme, Font.Normal, OnNext));
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
		}

		private void AddArmamentControls(CraftWeaponType craftWeapon)
		{
			var metadata = craftWeapon.Metadata();
			AddControl(new Overlay(metadata.Overlay, 4));
		}
	}
}
