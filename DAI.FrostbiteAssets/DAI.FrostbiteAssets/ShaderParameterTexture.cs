namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ShaderParameterTexture : LinkObject
	{
		[FieldOffset(0, 0)]
		public string ParameterName { get; set; }

		[FieldOffset(4, 8)]
		public ExternalObject<Dummy> Texture { get; set; }
	}
}
