namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MeshMaterialVariation : DataContainer
	{
		[FieldOffset(8, 24)]
		public SurfaceShaderInstanceDataStruct Shader { get; set; }
	}
}
