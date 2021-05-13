using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DA3DirectDamageTypeSource : DA3DamageTypeSource
	{
		[FieldOffset(8, 24)]
		public int DamageType { get; set; }

		[FieldOffset(12, 28)]
		public CSMWeaponSlot ContextWeapon { get; set; }
	}
}
