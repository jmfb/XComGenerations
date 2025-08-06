using XCom.Controls;
using XCom.Graphics;
using XCom.Music;
using XCom.Screens;

namespace XCom.Battlescape;

public class ActionOptions : Screen
{
	public ActionOptions()
	{
		AddControl(
			new ClickArea(
				0,
				0,
				GraphicsBuffer.GameWidth,
				GraphicsBuffer.GameHeight,
				EndModal,
				EndModal
			)
		);
		AddControl(new ActionOption(160, "Throw", null, 10, OnThrow, EndModal));
	}

	public override bool IsSilentModal => true;

	void OnThrow()
	{
		// TODO: Throw!
		WindowsSoundEffect.ButtonPush.Play();
		EndModal();
	}
}
