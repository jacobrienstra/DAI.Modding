namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CinebotNamedTrackableEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public string TrackableName { get; set; }
	}
}
