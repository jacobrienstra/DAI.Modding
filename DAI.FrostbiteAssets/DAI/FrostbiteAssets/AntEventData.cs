namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AntEventData : LinkObject
	{
		[FieldOffset(0, 0)]
		public int TagId { get; set; }

		[FieldOffset(4, 8)]
		public EventSpec Event { get; set; }
	}
}
