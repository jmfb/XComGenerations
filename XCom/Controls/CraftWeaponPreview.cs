using XCom.Data;
using XCom.Fonts;
using XCom.Graphics;

namespace XCom.Controls
{
	public class CraftWeaponPreview : Drawable
	{
		private readonly Craft craft;

		public CraftWeaponPreview(Craft craft)
		{
			this.craft = craft;
		}

		public void Render(GraphicsBuffer buffer)
		{
			RenderWeapon1(buffer);
			RenderWeapon2(buffer);
		}

		private void RenderWeapon1(GraphicsBuffer buffer)
		{
			if (craft.Weapons.Count < 1)
				return;
			var weapon = craft.Weapons[0];
			var metadata = weapon.WeaponType.Metadata();
			Font.Normal.DrawString(buffer, 48, 56, metadata.Name, ColorScheme.DarkYellow);
			Font.Normal.DrawString(buffer, 64, 56, "AMMO>", ColorScheme.Blue);
			Font.Normal.DrawString(buffer, 64, 82, weapon.Ammunition.FormatNumber(), ColorScheme.DarkYellow);
			Font.Normal.DrawString(buffer, 72, 56, "MAX>", ColorScheme.Blue);
			Font.Normal.DrawString(buffer, 72, 77, metadata.Ammunition.FormatNumber(), ColorScheme.DarkYellow);
			metadata.Image.Render(buffer, 63, 121);
		}

		private void RenderWeapon2(GraphicsBuffer buffer)
		{
			if (craft.Weapons.Count < 2)
				return;
			var weapon = craft.Weapons[1];
			var metadata = weapon.WeaponType.Metadata();
			Font.Normal.DrawString(buffer, 48, 204, metadata.Name, ColorScheme.DarkYellow);
			Font.Normal.DrawString(buffer, 64, 204, "AMMO>", ColorScheme.Blue);
			Font.Normal.DrawString(buffer, 64, 230, weapon.Ammunition.FormatNumber(), ColorScheme.DarkYellow);
			Font.Normal.DrawString(buffer, 72, 204, "MAX>", ColorScheme.Blue);
			Font.Normal.DrawString(buffer, 72, 225, metadata.Ammunition.FormatNumber(), ColorScheme.DarkYellow);
			metadata.Image.Render(buffer, 63, 184);
		}
	}
}
