namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LocalizedStringReference : LinkObject
	{
		[FieldOffset(0, 0)]
		public int StringId { get; set; }
	}
}
