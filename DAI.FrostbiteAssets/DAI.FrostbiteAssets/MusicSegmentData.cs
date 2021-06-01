namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MusicSegmentData : MusicStreamableData
	{
		[FieldOffset(64, 96)]
		public ExternalObject<SoundWaveAsset> Wave { get; set; }

		[FieldOffset(68, 104)]
		public ExternalObject<Dummy> MultitrackLayers { get; set; }
	}
}
