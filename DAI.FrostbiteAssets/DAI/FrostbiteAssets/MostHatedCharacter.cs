namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MostHatedCharacter : CSMEntityProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<EntityProvider_Self> SourceEntity { get; set; }
	}
}
