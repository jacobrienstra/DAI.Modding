namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CinebotFloatTrackData : FloatTrackData
	{
		[FieldOffset(36, 152)]
		public int TargetPropertyId { get; set; }
	}
}
