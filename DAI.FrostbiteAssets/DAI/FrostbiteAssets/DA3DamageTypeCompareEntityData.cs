using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DA3DamageTypeCompareEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 100)]
		public int DamageTypeCompare { get; set; }

		[FieldOffset(24, 104)]
		public int DamageType { get; set; }

		[FieldOffset(28, 108)]
		public bool InvertResult { get; set; }
	}
}
