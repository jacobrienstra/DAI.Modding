namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ForceGroupAsset : Asset
	{
		[FieldOffset(12, 72)]
		public bool MeshScattering { get; set; }

		[FieldOffset(13, 73)]
		public bool Vegetation { get; set; }

		[FieldOffset(14, 74)]
		public bool Effects { get; set; }

		[FieldOffset(15, 75)]
		public bool Cloth { get; set; }

		[FieldOffset(16, 76)]
		public bool Physics { get; set; }
	}
}
