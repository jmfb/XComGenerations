using XCom.Controls;
using XCom.Graphics;
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

	void OnThrow()
	{
		// TODO: Throw!
		EndModal();
	}
}
