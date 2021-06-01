namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ANTBoolTrackData : BoolTrackData
	{
		[FieldOffset(36, 152)]
		public AntRef Signal { get; set; }

		[FieldOffset(56, 200)]
		public bool ResetOnLeave { get; set; }

		[FieldOffset(57, 201)]
		public bool ResetValue { get; set; }
	}
}
