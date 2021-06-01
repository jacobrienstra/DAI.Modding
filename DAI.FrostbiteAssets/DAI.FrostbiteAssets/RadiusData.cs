namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class RadiusData : Asset
	{
		[FieldOffset(12, 72)]
		public float radius { get; set; }

		[FieldOffset(16, 76)]
		public float outerCushion { get; set; }

		[FieldOffset(20, 80)]
		public float innerCushion { get; set; }
	}
}
