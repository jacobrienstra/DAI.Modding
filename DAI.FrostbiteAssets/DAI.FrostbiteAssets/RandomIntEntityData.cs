using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class RandomIntEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 100)]
		public int Start { get; set; }

		[FieldOffset(24, 104)]
		public int Count { get; set; }

		[FieldOffset(28, 108)]
		public bool TrueRandom { get; set; }
	}
}
