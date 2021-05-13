namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CinebotVec3TrackData : Vec3TrackData
	{
		[FieldOffset(44, 168)]
		public int TargetPropertyId { get; set; }
	}
}
