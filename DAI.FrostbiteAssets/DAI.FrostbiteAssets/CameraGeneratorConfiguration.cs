namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CameraGeneratorConfiguration : DataContainer
	{
		[FieldOffset(8, 24)]
		public int CloseUpGroupMinSize { get; set; }

		[FieldOffset(12, 28)]
		public float CloseUpProbability { get; set; }

		[FieldOffset(16, 32)]
		public float CloseUpInDelay { get; set; }

		[FieldOffset(20, 36)]
		public float CloseUpOutDelay { get; set; }

		[FieldOffset(24, 40)]
		public float CloseUpInMinLength { get; set; }

		[FieldOffset(28, 44)]
		public float CloseUpOutMinLength { get; set; }

		[FieldOffset(32, 48)]
		public bool AlwaysCreateKeyframeAtLineStart { get; set; }

		[FieldOffset(33, 49)]
		public bool LookAtHeroAfterLine { get; set; }
	}
}
