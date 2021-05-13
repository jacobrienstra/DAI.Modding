namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EntityListProvider_ConditionalFilter : EntityListProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<EntityListProvider> EntityList { get; set; }

		[FieldOffset(12, 40)]
		public ExternalObject<BoolProvider> Condition { get; set; }
	}
}
