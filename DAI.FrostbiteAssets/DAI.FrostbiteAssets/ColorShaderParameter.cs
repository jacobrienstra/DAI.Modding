namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class ColorShaderParameter : Vec4ShaderParameter
	{
		[FieldOffset(32, 48)]
		public int PaletteIndex { get; set; }
	}
}
