namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MPServerMappingChallengeBase : DataContainer
	{
		[FieldOffset(8, 24)]
		public int SlotBit { get; set; }

		[FieldOffset(12, 28)]
		public int SlotID { get; set; }
	}
}
