namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class UpdateCameraProximityData : ProcessorData
	{
		[FieldOffset(16, 64)]
		public Vec3 Size { get; set; }

		[FieldOffset(32, 80)]
		public float ForwardOffset { get; set; }
	}
}
