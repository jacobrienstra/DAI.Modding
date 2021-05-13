namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EventSpec : LinkObject
	{
		[FieldOffset(0, 0)]
		public int Id { get; set; }
	}
}
