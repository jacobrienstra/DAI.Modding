namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class IntegerProviderEntityData : ProviderEntityData
	{
		[FieldOffset(24, 104)]
		public ExternalObject<IntegerProvider_ProfileOption> Provider { get; set; }
	}
}
