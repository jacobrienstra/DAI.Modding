namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIObjectiveDisplayInfo : LinkObject
	{
		[FieldOffset(0, 0)]
		public int Objective { get; set; }

		[FieldOffset(4, 8)]
		public UITextureAtlasTextureReference Icon { get; set; }

		[FieldOffset(24, 48)]
		public LocalizedStringReference DisplayText { get; set; }
	}
}
