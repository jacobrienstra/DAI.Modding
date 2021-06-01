namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class ScreenSpaceComposerTarget : LinkObject
	{
		[FieldOffset(0, 0)]
		public Vec3 Offset { get; set; }

		[FieldOffset(16, 16)]
		public string TargetPart { get; set; }

		[FieldOffset(20, 24)]
		public float MaxAngleSoft { get; set; }

		[FieldOffset(24, 28)]
		public float MaxAngleHard { get; set; }

		[FieldOffset(28, 32)]
		public bool Enabled { get; set; }
	}
}
