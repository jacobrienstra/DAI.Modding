namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BT_ForEachTarget : BTIteratorFunc
	{
		[FieldOffset(12, 32)]
		public ExternalObject<TargetListProvider> List { get; set; }
	}
}
