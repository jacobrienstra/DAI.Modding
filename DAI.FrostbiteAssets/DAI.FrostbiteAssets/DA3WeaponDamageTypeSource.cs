using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DA3WeaponDamageTypeSource : DA3DamageTypeSource
	{
		[FieldOffset(8, 24)]
		public CSMWeaponSlot SourceWeapon { get; set; }
	}
}
