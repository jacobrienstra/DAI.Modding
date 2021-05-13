namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class GameProjectileEntityData : GameProjectileEntityBaseData
	{
		[FieldOffset(192, 352)]
		public ExternalObject<DA3ImpactDescriptor> Impact { get; set; }
	}
}
