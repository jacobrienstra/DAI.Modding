namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ShaderGraph : SurfaceShaderBaseAsset
	{
		[FieldOffset(12, 72)]
		public uint NumTechniques { get; set; }
	}
}
