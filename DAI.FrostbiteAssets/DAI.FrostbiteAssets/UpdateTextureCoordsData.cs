using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UpdateTextureCoordsData : ProcessorData
	{
		[FieldOffset(16, 64)]
		public ExternalObject<AtlasTextureAsset> BaseTexture { get; set; }

		[FieldOffset(20, 72)]
		public ExternalObject<AtlasTextureAsset> NormalTexture { get; set; }

		[FieldOffset(24, 80)]
		public TexCoordModifier ModifierU { get; set; }

		[FieldOffset(28, 84)]
		public TexCoordModifier ModifierV { get; set; }

		[FieldOffset(32, 88)]
		public float ScaleU { get; set; }

		[FieldOffset(36, 92)]
		public float ScaleV { get; set; }

		[FieldOffset(40, 96)]
		public float BiasU { get; set; }

		[FieldOffset(44, 100)]
		public float BiasV { get; set; }
	}
}
