using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIScreenAsset : UIViewBaseAsset
	{
		[FieldOffset(48, 144)]
		public string SwfPath { get; set; }

		[FieldOffset(52, 152)]
		public UIScreenPurpose Purpose { get; set; }

		[FieldOffset(56, 156)]
		public bool OccludeOuterArea { get; set; }
	}
}
