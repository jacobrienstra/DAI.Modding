namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BoolProvider_EntityIsValid : BoolProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<CSMEntityProvider> Entity { get; set; }
	}
}
