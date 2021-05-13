namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CinebotTrackableTrackData : CinebotHeirarchicalTrackData
	{
		[FieldOffset(28, 136)]
		public ExternalObject<EntityTrackData> TrackableOverride { get; set; }
	}
}
