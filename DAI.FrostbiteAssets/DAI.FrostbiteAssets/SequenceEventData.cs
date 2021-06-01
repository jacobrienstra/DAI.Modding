namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SequenceEventData : LinkObject
	{
		[FieldOffset(0, 0)]
		public EventSpec Event { get; set; }

		[FieldOffset(4, 16)]
		public int Time { get; set; }
	}
}
