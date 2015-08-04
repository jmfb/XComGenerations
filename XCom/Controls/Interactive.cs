namespace XCom.Controls
{
	public interface Interactive
	{
		void OnKeyPressed(char value);
		void OnMouseMove(int row, int column, bool leftButton, bool rightButton);
		void OnLeftButtonDown(int row, int column);
		void OnLeftButtonUp(int row, int column);
		void OnRightButtonDown(int row, int column);
		void OnRightButtonUp(int row, int column);

		bool HitTest(int row, int column);
		bool IsChild(Interactive parent);
	}
}
