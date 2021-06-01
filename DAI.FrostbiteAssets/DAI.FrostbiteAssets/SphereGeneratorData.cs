namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SphereGeneratorData : DataContainer
	{
		[FieldOffset(8, 24)]
		public float StartAngle { get; set; }

		[FieldOffset(12, 28)]
		public float EndAngle { get; set; }

		[FieldOffset(16, 32)]
		public float StartAzimuth { get; set; }

		[FieldOffset(20, 36)]
		public float EndAzimuth { get; set; }

		[FieldOffset(24, 40)]
		public float StartRadius { get; set; }

		[FieldOffset(28, 44)]
		public float EndRadius { get; set; }
	}
}
