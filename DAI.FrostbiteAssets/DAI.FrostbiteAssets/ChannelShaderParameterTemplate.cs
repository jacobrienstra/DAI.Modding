namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class ChannelShaderParameterTemplate : ShaderParameterTemplate
	{
		[FieldOffset(16, 48)]
		public Vec4 Default { get; set; }

		[FieldOffset(32, 64)]
		public string PresentationName { get; set; }

		[FieldOffset(36, 72)]
		public bool AlphaEnabled { get; set; }
	}
}
