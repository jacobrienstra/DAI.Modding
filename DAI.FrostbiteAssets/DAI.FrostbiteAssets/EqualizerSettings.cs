namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EqualizerSettings : DataContainer
	{
		[FieldOffset(8, 24)]
		public float LowShelfFrequency { get; set; }

		[FieldOffset(12, 28)]
		public float LowShelfGain { get; set; }

		[FieldOffset(16, 32)]
		public float HighShelfFrequency { get; set; }

		[FieldOffset(20, 36)]
		public float HighShelfGain { get; set; }

		[FieldOffset(24, 40)]
		public float HpCutoffFrequency { get; set; }
	}
}
