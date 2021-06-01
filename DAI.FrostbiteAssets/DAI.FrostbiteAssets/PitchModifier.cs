namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class PitchModifier
	{
		[FieldOffset(0, 0)]
		public Vec3 Offset { get; set; }

		[FieldOffset(16, 16)]
		public float PitchVal { get; set; }

		[FieldOffset(20, 20)]
		public float PitchAngle { get; set; }
	}
}
