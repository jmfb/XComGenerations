using XCom.Controls;
using XCom.Music;

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
			SoundEffectType.WindowOpen.Play();
			OnSetFocus();
		}

		protected void EndModal()
		{
			OnKillFocus();
			SoundEffectType.WindowClose.Play();
			GameState.Current.Dispatcher.ReleaseFocus();
			ModalParent.RemoveControl(this);
			ModalParent.OnSetFocus();
		}

		protected void SwitchToModal(Screen newModal)
		{
			var currentParent = ModalParent;
			EndModal();
			newModal.DoModal(currentParent);
		}

		public static readonly Geoscape Geoscape = new Geoscape();
	}
}
