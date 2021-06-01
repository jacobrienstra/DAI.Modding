using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class RandomFloatEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 100)]
		public float Min { get; set; }

		[FieldOffset(24, 104)]
		public float Max { get; set; }

		[FieldOffset(28, 108)]
		public bool TrueRandom { get; set; }
	}
}
