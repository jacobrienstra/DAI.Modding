using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PlayerIteratorEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 100)]
		public TeamId Team { get; set; }

		[FieldOffset(24, 104)]
		public bool Alive { get; set; }

		[FieldOffset(25, 105)]
		public bool RandomizeFromStart { get; set; }
	}
}
