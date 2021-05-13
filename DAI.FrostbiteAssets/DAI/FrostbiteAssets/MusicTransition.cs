namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MusicTransition : DataContainer
	{
		[FieldOffset(8, 24)]
		public ExternalObject<MusicPhraseData> Source { get; set; }

		[FieldOffset(12, 32)]
		public ExternalObject<Dummy> Destination { get; set; }

		[FieldOffset(16, 40)]
		public ExternalObject<BasicFadeData> Fade { get; set; }

		[FieldOffset(20, 48)]
		public ExternalObject<Dummy> OverlayControl { get; set; }
	}
}
