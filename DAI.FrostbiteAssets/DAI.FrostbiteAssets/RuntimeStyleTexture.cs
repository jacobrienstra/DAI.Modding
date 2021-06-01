namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class RuntimeStyleTexture : LinkObject
	{
		[FieldOffset(0, 0)]
		public string ShaderParameterName { get; set; }

		[FieldOffset(4, 8)]
		public ExternalObject<TextureAsset> Value { get; set; }
	}
}
