namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DefaultANTLayerData : ANTLayerData
	{
		[FieldOffset(28, 136)]
		public AntRef BlendMaskList { get; set; }

		[FieldOffset(48, 184)]
		public ExternalObject<ANTClipKeyframeTrackData> ClipTrack { get; set; }

		[FieldOffset(52, 192)]
		public ExternalObject<ANTBlendKeyframeTrackData> BlendTrack { get; set; }
	}
}
