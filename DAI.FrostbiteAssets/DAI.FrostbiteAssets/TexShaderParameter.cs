namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class TexShaderParameter : ShaderParameter
	{
		[FieldOffset(12, 32)]
		public ExternalObject<TextureAsset> Texture { get; set; }
	}
}
