namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MeshSocketPair : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<AppearanceMeshSet> MeshSet { get; set; }

		[FieldOffset(4, 8)]
		public ExternalObject<AppearanceSocketInfo> Socket { get; set; }
	}
}
