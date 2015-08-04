﻿using XCom.Controls;

namespace XCom.Screens
{
	public abstract class Screen : InteractiveContainer
	{
		protected Screen ModalParent { get; private set; }
		public virtual void OnSetFocus()
		{
		}

		public virtual void OnKillFocus()
		{
		}

		public void DoModal(Screen parent)
		{
			ModalParent = parent;
			parent.OnKillFocus();
			parent.AddControl(this);
			GameState.Current.Dispatcher.CaptureFocus(this);
			OnSetFocus();
		}

		protected void EndModal()
		{
			OnKillFocus();
			GameState.Current.Dispatcher.ReleaseFocus();
			ModalParent.RemoveControl(this);
			ModalParent.OnSetFocus();
		}

		protected static readonly Geoscape Geoscape = new Geoscape();
	}
}
