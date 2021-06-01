namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class ANTVec3TrackData : Vec3TrackData
	{
		[FieldOffset(44, 168)]
		public AntRef Signal { get; set; }

		[FieldOffset(64, 224)]
		public Vec3 ResetValue { get; set; }

		[FieldOffset(80, 240)]
		public bool ResetOnLeave { get; set; }
	}
}
