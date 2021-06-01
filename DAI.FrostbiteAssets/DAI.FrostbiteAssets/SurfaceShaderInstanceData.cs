namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SurfaceShaderInstanceData : DataContainer
	{
		[FieldOffset(8, 24)]
		public ExternalObject<Dummy> Shader { get; set; }
	}
}
