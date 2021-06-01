namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class GameProjectileParabola
	{
		[FieldOffset(0, 0)]
		public float MaxRange { get; set; }

		[FieldOffset(4, 4)]
		public float MaxHeight { get; set; }
	}
}
