namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class TerrainMeshScatteringType : DataContainer
	{
		[FieldOffset(8, 24)]
		public uint Identifier { get; set; }

		[FieldOffset(12, 28)]
		public Vec2 MinScale { get; set; }

		[FieldOffset(20, 36)]
		public Vec2 MaxScale { get; set; }

		[FieldOffset(28, 44)]
		public float ScaleRandomness { get; set; }

		[FieldOffset(32, 48)]
		public QualityScalableFloat Density { get; set; }

		[FieldOffset(48, 64)]
		public uint FirstSpawnLevel { get; set; }

		[FieldOffset(52, 68)]
		public float WindScale { get; set; }

		[FieldOffset(56, 72)]
		public float Stiffness { get; set; }

		[FieldOffset(60, 76)]
		public float Damping { get; set; }

		[FieldOffset(64, 80)]
		public float Mass { get; set; }

		[FieldOffset(68, 84)]
		public float WindWiggle { get; set; }
	}
}
