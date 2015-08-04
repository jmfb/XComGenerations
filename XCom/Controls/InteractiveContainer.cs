using System.Collections.Generic;
using System.Linq;
using XCom.Graphics;

namespace XCom.Controls
{
	public abstract class InteractiveContainer : InteractiveControl
	{
		private readonly List<object> controls = new List<object>();

		protected void AddControl(object control)
		{
			controls.Add(control);
		}

		protected void RemoveControl(object control)
		{
			controls.Remove(control);
		}

		public override void OnMouseMove(int row, int column, bool leftButton, bool rightButton)
		{
			var target = FindControl(row, column);
			if (target != null)
				target.OnMouseMove(row, column, leftButton, rightButton);
		}

		public override void OnLeftButtonDown(int row, int column)
		{
			var target = FindControl(row, column);
			if (target != null)
				target.OnLeftButtonDown(row, column);
		}

		public override void OnLeftButtonUp(int row, int column)
		{
			var target = FindControl(row, column);
			if (target != null)
				target.OnLeftButtonUp(row, column);
		}

		public override void OnRightButtonDown(int row, int column)
		{
			var target = FindControl(row, column);
			if (target != null)
				target.OnRightButtonDown(row, column);
		}

		public override void OnRightButtonUp(int row, int column)
		{
			var target = FindControl(row, column);
			if (target != null)
				target.OnRightButtonUp(row, column);
		}

		public override bool IsChild(Interactive parent)
		{
			return controls
				.OfType<Interactive>()
				.Any(control => ReferenceEquals(control, parent) || control.IsChild(parent));
		}

		public override void Render(GraphicsBuffer buffer)
		{
			foreach (var drawable in controls.OfType<Drawable>())
				drawable.Render(buffer);
		}

		public override bool HitTest(int row, int column)
		{
			return controls
				.OfType<Interactive>()
				.Any(control => control.HitTest(row, column));
		}

		private Interactive FindControl(int row, int column)
		{
			return controls
				.OfType<Interactive>()
				.Reverse()
				.FirstOrDefault(control => control.HitTest(row, column));
		}
	}
}
