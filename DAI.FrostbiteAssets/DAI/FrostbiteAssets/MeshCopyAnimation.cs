namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MeshCopyAnimation : LinkObject
	{
		[FieldOffset(0, 0)]
		public AntRef Controller { get; set; }
	}
}
