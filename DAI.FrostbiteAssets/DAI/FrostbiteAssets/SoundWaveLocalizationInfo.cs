namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SoundWaveLocalizationInfo : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<AudioLanguage> Language { get; set; }

		[FieldOffset(4, 8)]
		public short FirstVariationIndex { get; set; }

		[FieldOffset(6, 10)]
		public short VariationCount { get; set; }
	}
}
