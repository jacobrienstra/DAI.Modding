namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MemoryLevelDescriptionComponent : LevelDescriptionComponent
	{
		[FieldOffset(8, 24)]
		public int TexturePoolSize { get; set; }

		[FieldOffset(12, 28)]
		public int TexturePoolSizeXenon { get; set; }

		[FieldOffset(16, 32)]
		public int TexturePoolSizePs3 { get; set; }

		[FieldOffset(20, 36)]
		public int MeshPoolSizePs3 { get; set; }

		[FieldOffset(24, 40)]
		public int MeshPoolSizePs3Cell { get; set; }

		[FieldOffset(28, 44)]
		public int MeshPoolSizeXenon { get; set; }

		[FieldOffset(32, 48)]
		public QualityScalableInt EmitterBaseAtlasWidth { get; set; }

		[FieldOffset(48, 64)]
		public QualityScalableInt EmitterBaseAtlasHeight { get; set; }

		[FieldOffset(64, 80)]
		public QualityScalableInt EmitterBaseAtlasMipmapCount { get; set; }

		[FieldOffset(80, 96)]
		public QualityScalableInt EmitterNormalAtlasWidth { get; set; }

		[FieldOffset(96, 112)]
		public QualityScalableInt EmitterNormalAtlasHeight { get; set; }

		[FieldOffset(112, 128)]
		public QualityScalableInt EmitterNormalAtlasMipmapCount { get; set; }
	}
}
