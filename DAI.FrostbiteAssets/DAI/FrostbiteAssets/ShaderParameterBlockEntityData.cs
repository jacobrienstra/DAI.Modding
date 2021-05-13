using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ShaderParameterBlockEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public List<BoolShaderParameter> BoolParameters { get; set; }

		[FieldOffset(20, 104)]
		public List<VectorShaderParameter> VectorParameters { get; set; }

		[FieldOffset(24, 112)]
		public List<TextureShaderParameter> TextureParameters { get; set; }

		public ShaderParameterBlockEntityData()
		{
			BoolParameters = new List<BoolShaderParameter>();
			VectorParameters = new List<VectorShaderParameter>();
			TextureParameters = new List<TextureShaderParameter>();
		}
	}
}
