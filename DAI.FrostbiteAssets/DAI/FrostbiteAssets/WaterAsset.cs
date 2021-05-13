namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(8)]
	public class WaterAsset : Asset
	{
		[FieldOffset(16, 72)]
		public long PhysicsResource { get; set; }
	}
}
