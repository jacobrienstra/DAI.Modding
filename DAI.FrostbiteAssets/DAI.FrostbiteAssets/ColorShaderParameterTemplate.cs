namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ColorShaderParameterTemplate : ShaderParameterTemplate
	{
		[FieldOffset(16, 40)]
		public ExternalObject<ColorPalette> Colors { get; set; }

		[FieldOffset(20, 48)]
		public int Default { get; set; }

		[FieldOffset(24, 56)]
		public string PresentationName { get; set; }
	}
}
