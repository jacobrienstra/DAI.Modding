namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class TransformProviderEntityData : ProviderEntityData
	{
		[FieldOffset(24, 104)]
		public ExternalObject<TransformProvider> Provider { get; set; }
	}
}
