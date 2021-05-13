using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SubLevelStreamingActivatorEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public int Category { get; set; }

		[FieldOffset(20, 100)]
		public SubLevelStreamingActivatorType ActivatorType { get; set; }

		[FieldOffset(24, 104)]
		public bool Enabled { get; set; }
	}
}
