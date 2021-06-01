namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CinebotNamedTrackableSpatialEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public string TrackableName { get; set; }
	}
}
