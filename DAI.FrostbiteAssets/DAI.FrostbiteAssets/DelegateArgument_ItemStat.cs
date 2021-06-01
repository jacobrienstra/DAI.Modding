namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DelegateArgument_ItemStat : DelegateArgument
	{
		[FieldOffset(12, 40)]
		public ExternalObject<Dummy> Value { get; set; }
	}
}
