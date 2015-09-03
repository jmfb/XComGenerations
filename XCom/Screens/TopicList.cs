using XCom.Content.Backgrounds;
using XCom.Controls;
using XCom.Data;
using XCom.Graphics;
using Font = XCom.Fonts.Font;

namespace XCom.Screens
{
	public class TopicList : Screen
	{
		private readonly TopicCategory category;

		public TopicList(TopicCategory category)
		{
			this.category = category;

			AddControl(new Border(10, 32, 256, 180, ColorScheme.Green, Backgrounds.Title, 0));
			AddControl(new Label(24, Label.Center, "SELECT ITEM", Font.Large, ColorScheme.Yellow));

			var topics = GameState.Current.Data.GetTopics(category);
			var selectionColor = Palette.GetPalette(12).GetColor(230);
			AddControl(new ListView<TopicType>(50, 40, 14, topics, ColorScheme.Aqua, selectionColor, OnSelectTopic)
				.AddColumn(224, Alignment.Center, item => item.Metadata().Name));

			AddControl(new Button(166, 48, 224, 16, "OK", ColorScheme.Green, Font.Normal, OnOk));
		}

		private static void OnOk()
		{
			GameState.Current.SetScreen(new Information());
		}

		private void OnSelectTopic(TopicType topic)
		{
			GameState.Current.SetScreen(new TopicView(category, topic));
		}
	}
}
