namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EntityListAdaptor : TargetListProvider
	{
		[FieldOffset(8, 24)]
		public ExternalObject<CSMEntityListProvider> List { get; set; }

		[FieldOffset(12, 32)]
		public bool ExcludeSelf { get; set; }

		[FieldOffset(13, 33)]
		public bool ExcludeDisabled { get; set; }

		[FieldOffset(14, 34)]
		public bool ExcludeDisabledInCombat { get; set; }
	}
}
