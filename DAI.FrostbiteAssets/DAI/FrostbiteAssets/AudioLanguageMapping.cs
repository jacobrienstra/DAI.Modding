namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AudioLanguageMapping : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<AudioLanguage> Source { get; set; }

		[FieldOffset(4, 8)]
		public ExternalObject<AudioLanguage> Target { get; set; }
	}
}
