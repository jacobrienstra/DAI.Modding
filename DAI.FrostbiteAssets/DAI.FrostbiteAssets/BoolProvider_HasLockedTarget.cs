namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BoolProvider_HasLockedTarget : BoolProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<EntityProvider_Self> SourceEntityProvider { get; set; }
	}
}
