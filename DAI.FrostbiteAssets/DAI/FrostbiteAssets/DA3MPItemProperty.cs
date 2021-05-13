namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DA3MPItemProperty
	{
		[FieldOffset(0, 0)]
		public int PropertyId { get; set; }

		[FieldOffset(4, 4)]
		public int PropertyValue { get; set; }
	}
}
