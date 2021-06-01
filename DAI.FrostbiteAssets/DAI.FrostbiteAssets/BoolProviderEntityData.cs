namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BoolProviderEntityData : ProviderEntityData
	{
		[FieldOffset(24, 104)]
		public ExternalObject<BoolProvider> Provider { get; set; }
	}
}
