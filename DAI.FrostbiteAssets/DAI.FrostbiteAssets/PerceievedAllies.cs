namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PerceievedAllies : CSMEntityListProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<EntityProvider_Self> SourceEntity { get; set; }
	}
}
