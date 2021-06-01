namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ShaderParametersInstance : Asset
	{
		[FieldOffset(12, 72)]
		public OverrideShaderParameters Parameters { get; set; }
	}
}
