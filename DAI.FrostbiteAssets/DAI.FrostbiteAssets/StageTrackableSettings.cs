namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class StageTrackableSettings : DataContainer
	{
		[FieldOffset(8, 24)]
		public string TrackableName { get; set; }
	}
}
