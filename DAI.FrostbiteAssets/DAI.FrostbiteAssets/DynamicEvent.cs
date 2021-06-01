namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DynamicEvent : LinkObject
	{
		[FieldOffset(0, 0)]
		public int Id { get; set; }
	}
}
