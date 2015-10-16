using System.Web.Script.Serialization;
using XCom.Data;

namespace XCom.Battlescape
{
	public class BattleItem
	{
		public object Item { get; set; }
		public AmmunitionType? Ammunition { get; set; }
		public int Rounds { get; set; }

		[ScriptIgnore]
		public byte[] Image => ImageOf((dynamic)Item);
		private static byte[] ImageOf(WeaponType weaponType) => weaponType.Metadata().Image;
		private static byte[] ImageOf(AmmunitionType ammunitionType) => ammunitionType.Metadata().Image;
		private static byte[] ImageOf(EquipmentType equipmentType) => equipmentType.Metadata().Image;

		[ScriptIgnore]
		public int Width => WidthOf((dynamic)Item);
		private static int WidthOf(WeaponType weaponType) => weaponType.Metadata().Width;
		private static int WidthOf(AmmunitionType ammunitionType) => ammunitionType.Metadata().Width;
		private static int WidthOf(EquipmentType equipmentType) => equipmentType.Metadata().Width;

		[ScriptIgnore]
		public int Height => HeightOf((dynamic)Item);
		private static int HeightOf(WeaponType weaponType) => weaponType.Metadata().Height;
		private static int HeightOf(AmmunitionType ammunitionType) => ammunitionType.Metadata().Height;
		private static int HeightOf(EquipmentType equipmentType) => equipmentType.Metadata().Height;
	}
}
