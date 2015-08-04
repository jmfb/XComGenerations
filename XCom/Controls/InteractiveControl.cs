using XCom.Graphics;

namespace XCom.Controls
{
	public abstract class InteractiveControl : Interactive, Drawable
	{
		public virtual void OnKeyPressed(char value)
		{
		}

		public virtual void OnMouseMove(int row, int column, bool leftButton, bool rightButton)
		{
		}

		public virtual void OnLeftButtonDown(int row, int column)
		{
		}

		public virtual void OnLeftButtonUp(int row, int column)
		{
		}

		public virtual void OnRightButtonDown(int row, int column)
		{
		}

		public virtual void OnRightButtonUp(int row, int column)
		{
		}

		public virtual bool HitTest(int row, int column)
		{
			return false;
		}

		public virtual bool IsChild(Interactive parent)
		{
			return false;
		}

		public abstract void Render(GraphicsBuffer buffer);
	}
}
