namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EntityProvider_Any : EntityProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<CSMEntityListProvider> EntityList { get; set; }
	}
}
