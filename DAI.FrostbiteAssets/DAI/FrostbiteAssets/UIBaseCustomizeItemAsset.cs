using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIBaseCustomizeItemAsset : UITreeFlowAsset
	{
		[FieldOffset(64, 216)]
		public ExternalObject<TextureAsset> Texture { get; set; }

		[FieldOffset(68, 224)]
		public UITreeFlowChildType ChildListType { get; set; }

		[FieldOffset(72, 232)]
		public PlotFlagReference UnlockPlotFlag { get; set; }

		[FieldOffset(88, 272)]
		public PlotFlagReference StylePlotFlag { get; set; }

		[FieldOffset(104, 312)]
		public int StyleID { get; set; }

		[FieldOffset(108, 316)]
		public int DLCPackage { get; set; }
	}
}
