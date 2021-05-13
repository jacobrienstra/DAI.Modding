namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BoolProvider_CachedBool : BoolProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<BWConditional> Provider { get; set; }
	}
}
