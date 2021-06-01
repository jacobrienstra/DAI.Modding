namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(8)]
	public class RagdollAsset : Asset
	{
		[FieldOffset(12, 72)]
		public MaterialDecl MaterialPair { get; set; }

		[FieldOffset(16, 88)]
		public long Resource { get; set; }

		[FieldOffset(24, 96)]
		public bool UseServerRagdoll { get; set; }
	}
}
