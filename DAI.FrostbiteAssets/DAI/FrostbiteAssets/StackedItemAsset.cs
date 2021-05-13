using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class StackedItemAsset : BaseItemAsset
	{
		[FieldOffset(80, 248)]
		public StackedItemCategory Category { get; set; }

		[FieldOffset(84, 256)]
		public PlotFlagReference CountFlag { get; set; }

		[FieldOffset(100, 296)]
		public byte MaxStack { get; set; }

		[FieldOffset(101, 297)]
		public bool SaveEmptyStack { get; set; }
	}
}
