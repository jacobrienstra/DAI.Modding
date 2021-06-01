namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SchematicPinTrackData : TimelineTrackData
	{
		[FieldOffset(24, 128)]
		public int SourcePinId { get; set; }

		[FieldOffset(28, 132)]
		public int TargetPinId { get; set; }
	}
}
