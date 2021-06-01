using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(8)]
	public class StaticEnlightenData : Asset
	{
		[FieldOffset(12, 72)]
		public ExternalObject<TextureAsset> StaticIrradianceChromaTexture { get; set; }

		[FieldOffset(16, 80)]
		public long DatabaseResource { get; set; }

		[FieldOffset(24, 88)]
		public ExternalObject<TextureAsset> StaticIrradianceLumaTexture { get; set; }

		[FieldOffset(28, 96)]
		public ExternalObject<TextureAsset> StaticDirectionTexture { get; set; }

		[FieldOffset(32, 104)]
		public List<ExternalObject<TextureAsset>> StaticCubeMapTextures { get; set; }

		[FieldOffset(36, 112)]
		public bool StaticGen4Enable { get; set; }

		[FieldOffset(37, 113)]
		public bool CubeMapsGen3Enable { get; set; }

		[FieldOffset(38, 114)]
		public bool TextureCompressionEnable { get; set; }

		[FieldOffset(39, 115)]
		public bool ChromaCompressionEnable { get; set; }

		public StaticEnlightenData()
		{
			StaticCubeMapTextures = new List<ExternalObject<TextureAsset>>();
		}
	}
}
