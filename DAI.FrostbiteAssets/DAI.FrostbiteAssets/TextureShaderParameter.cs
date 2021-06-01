namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class TextureShaderParameter : LinkObject
	{
		[FieldOffset(0, 0)]
		public string ParameterName { get; set; }

		[FieldOffset(4, 8)]
		public ExternalObject<TextureAsset> Value { get; set; }
	}
}
