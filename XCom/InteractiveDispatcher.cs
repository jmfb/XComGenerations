﻿using System.Collections.Generic;
using XCom.Controls;

namespace XCom
{
	public class InteractiveDispatcher
	{
		private Interactive activeFocus;
		private readonly Stack<Interactive> focusHistory = new Stack<Interactive>();

		public void CaptureFocus(Interactive newFocus)
		{
			if (activeFocus != null)
				focusHistory.Push(activeFocus);
			activeFocus = newFocus;
		}

		public void ReleaseFocus()
		{
			activeFocus = focusHistory.Count == 0 ? null : focusHistory.Pop();
		}

		public void OnKeyPressed(char value)
		{
			if (activeFocus != null)
				activeFocus.OnKeyPressed(value);
		}

		public void OnMouseMove(int row, int column, bool leftButton, bool rightButton)
		{
			if (activeFocus != null)
				activeFocus.OnMouseMove(row, column, leftButton, rightButton);
		}

		public void OnLeftButtonDown(int row, int column)
		{
			if (activeFocus != null)
				activeFocus.OnLeftButtonDown(row, column);
		}

		public void OnLeftButtonUp(int row, int column)
		{
			if (activeFocus != null)
				activeFocus.OnLeftButtonUp(row, column);
		}

		public void OnRightButtonDown(int row, int column)
		{
			if (activeFocus != null)
				activeFocus.OnRightButtonDown(row, column);
		}

		public void OnRightButtonUp(int row, int column)
		{
			if (activeFocus != null)
				activeFocus.OnRightButtonUp(row, column);
		}
	}
}
