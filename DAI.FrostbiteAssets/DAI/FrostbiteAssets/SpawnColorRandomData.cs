namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class SpawnColorRandomData : ProcessorData
	{
		[FieldOffset(16, 64)]
		public Vec3 Color0 { get; set; }

		[FieldOffset(32, 80)]
		public Vec3 Color1 { get; set; }
	}
}
