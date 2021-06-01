namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LookConstraintsData
	{
		[FieldOffset(0, 0)]
		public float MinLookYaw { get; set; }

		[FieldOffset(4, 4)]
		public float MaxLookYaw { get; set; }

		[FieldOffset(8, 8)]
		public float MinLookPitch { get; set; }

		[FieldOffset(12, 12)]
		public float MaxLookPitch { get; set; }
	}
}
