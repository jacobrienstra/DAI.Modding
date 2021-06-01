namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CinebotTrackableData : EntityData
	{
		[FieldOffset(16, 96)]
		public uint TrackableID { get; set; }

		[FieldOffset(20, 104)]
		public string TrackableName { get; set; }
	}
}
