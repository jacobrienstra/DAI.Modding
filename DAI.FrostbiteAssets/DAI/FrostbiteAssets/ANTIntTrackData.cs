namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ANTIntTrackData : IntTrackData
	{
		[FieldOffset(36, 152)]
		public AntRef Signal { get; set; }

		[FieldOffset(56, 200)]
		public int ResetValue { get; set; }

		[FieldOffset(60, 204)]
		public bool ResetOnLeave { get; set; }
	}
}
