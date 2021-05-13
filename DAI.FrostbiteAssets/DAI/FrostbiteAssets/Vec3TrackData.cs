namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class Vec3TrackData : PropertyTrackBaseData
	{
		[FieldOffset(32, 144)]
		public ExternalObject<FloatTrackData> X { get; set; }

		[FieldOffset(36, 152)]
		public ExternalObject<FloatTrackData> Y { get; set; }

		[FieldOffset(40, 160)]
		public ExternalObject<FloatTrackData> Z { get; set; }
	}
}
