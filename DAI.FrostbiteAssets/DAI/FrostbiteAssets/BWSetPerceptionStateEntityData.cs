using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWSetPerceptionStateEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 100)]
		public PerceptionState State { get; set; }

		[FieldOffset(24, 104)]
		public bool ResetToDefaultState { get; set; }
	}
}
