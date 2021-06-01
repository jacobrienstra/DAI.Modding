namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AutoTarget : CSMEntityProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<EntityProvider_Self> ReferenceEntityProvider { get; set; }
	}
}
