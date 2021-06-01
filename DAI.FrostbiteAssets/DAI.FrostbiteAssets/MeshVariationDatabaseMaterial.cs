using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MeshVariationDatabaseMaterial : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<MeshMaterial> Material { get; set; }

		[FieldOffset(4, 8)]
		public ExternalObject<MeshMaterialVariation> MaterialVariation { get; set; }

		[FieldOffset(8, 16)]
		public List<TextureShaderParameter> TextureParameters { get; set; }

		public MeshVariationDatabaseMaterial()
		{
			TextureParameters = new List<TextureShaderParameter>();
		}
	}
}
