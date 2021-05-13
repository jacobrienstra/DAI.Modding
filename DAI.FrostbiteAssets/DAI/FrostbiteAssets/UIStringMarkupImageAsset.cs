namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIStringMarkupImageAsset : UIStringMarkupAsset
	{
		[FieldOffset(16, 40)]
		public UIStringMarkupImageData Image { get; set; }
	}
}
