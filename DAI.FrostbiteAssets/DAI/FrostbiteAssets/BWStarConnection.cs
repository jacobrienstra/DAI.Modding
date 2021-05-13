namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWStarConnection
	{
		[FieldOffset(0, 0)]
		public int SourceID { get; set; }

		[FieldOffset(4, 4)]
		public int TargetID { get; set; }
	}
}
