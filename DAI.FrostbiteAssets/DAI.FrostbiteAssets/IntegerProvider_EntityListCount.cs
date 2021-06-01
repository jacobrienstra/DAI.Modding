namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class IntegerProvider_EntityListCount : IntegerProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<EntityListProvider_ConditionalFilter> EntityList { get; set; }
	}
}
