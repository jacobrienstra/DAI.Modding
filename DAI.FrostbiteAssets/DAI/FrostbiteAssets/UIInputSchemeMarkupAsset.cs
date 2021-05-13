using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIInputSchemeMarkupAsset : UIStringMarkupAsset
	{
		[FieldOffset(16, 40)]
		public UIInputScheme InputScheme { get; set; }
	}
}
