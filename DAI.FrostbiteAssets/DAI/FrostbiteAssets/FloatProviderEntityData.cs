namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FloatProviderEntityData : ProviderEntityData
	{
		[FieldOffset(24, 104)]
		public ExternalObject<FloatProvider> Provider { get; set; }
	}
}
