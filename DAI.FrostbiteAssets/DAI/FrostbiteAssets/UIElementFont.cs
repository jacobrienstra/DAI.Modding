namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIElementFont : LinkObject
	{
		[FieldOffset(0, 0)]
		public string ScaleformFontName { get; set; }

		[FieldOffset(4, 8)]
		public float FontSize { get; set; }
	}
}
