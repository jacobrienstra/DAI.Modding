using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class RandomEventEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 100)]
		public int Probability { get; set; }

		[FieldOffset(24, 104)]
		public bool RandomizeFirstOnly { get; set; }

		[FieldOffset(25, 105)]
		public bool AutoStart { get; set; }
	}
}
