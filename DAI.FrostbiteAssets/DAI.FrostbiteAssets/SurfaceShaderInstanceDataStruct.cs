using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SurfaceShaderInstanceDataStruct : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<ShaderGraph> Shader { get; set; }

		[FieldOffset(4, 8)]
		public List<BoolShaderParameter> BoolParameters { get; set; }

		[FieldOffset(8, 16)]
		public List<VectorShaderParameter> VectorParameters { get; set; }

		[FieldOffset(12, 24)]
		public List<VectorArrayShaderParameter> VectorArrayParameters { get; set; }

		[FieldOffset(16, 32)]
		public List<TextureShaderParameter> TextureParameters { get; set; }

		public SurfaceShaderInstanceDataStruct()
		{
			BoolParameters = new List<BoolShaderParameter>();
			VectorParameters = new List<VectorShaderParameter>();
			VectorArrayParameters = new List<VectorArrayShaderParameter>();
			TextureParameters = new List<TextureShaderParameter>();
		}
	}
}
