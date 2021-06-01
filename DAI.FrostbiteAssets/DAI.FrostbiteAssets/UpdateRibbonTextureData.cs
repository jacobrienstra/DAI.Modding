namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UpdateRibbonTextureData : ProcessorData
	{
		[FieldOffset(16, 64)]
		public int TextureParticleCount { get; set; }

		[FieldOffset(20, 68)]
		public bool MirrorTexture { get; set; }

		[FieldOffset(21, 69)]
		public bool BeamLikeCoords { get; set; }
	}
}
