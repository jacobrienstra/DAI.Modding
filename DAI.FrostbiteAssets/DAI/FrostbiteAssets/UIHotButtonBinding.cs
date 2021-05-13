namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIHotButtonBinding : UIDataBinding
	{
		[FieldOffset(8, 24)]
		public UITextureAtlasTextureReference ButtonIconOn { get; set; }

		[FieldOffset(28, 64)]
		public UITextureAtlasTextureReference ButtonIconOff { get; set; }
	}
}
