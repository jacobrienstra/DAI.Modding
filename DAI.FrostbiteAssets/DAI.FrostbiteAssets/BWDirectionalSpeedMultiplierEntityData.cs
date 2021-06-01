using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWDirectionalSpeedMultiplierEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }
	}
}
