namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PoseGeneratorConfiguration : DataContainer
	{
		[FieldOffset(8, 24)]
		public int MinLinesBeforeChange { get; set; }

		[FieldOffset(12, 28)]
		public float InitialChangeProbability { get; set; }

		[FieldOffset(16, 32)]
		public float ChangeProbabilityIncrease { get; set; }

		[FieldOffset(20, 36)]
		public float TransitionTimeFromEndMin { get; set; }

		[FieldOffset(24, 40)]
		public float TransitionTimeFromEndMax { get; set; }
	}
}
