namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EntityProvider_RandomFromList : EntityProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<EntityListProvider> EntityList { get; set; }

		[FieldOffset(12, 40)]
		public int RandomSeed { get; set; }
	}
}
