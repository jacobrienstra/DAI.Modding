using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class OverrideShaderParameters : LinkObject
	{
		[FieldOffset(0, 0)]
		public List<ExternalObject<ShaderGraph>> Shaders { get; set; }

		[FieldOffset(4, 8)]
		public List<BoolShaderParameter> BoolParameters { get; set; }

		[FieldOffset(8, 16)]
		public List<VectorShaderParameter> VectorParameters { get; set; }

		[FieldOffset(12, 24)]
		public List<VectorArrayShaderParameter> VectorArrayParameters { get; set; }

		[FieldOffset(16, 32)]
		public List<TextureShaderParameter> TextureParameters { get; set; }

		public OverrideShaderParameters()
		{
			Shaders = new List<ExternalObject<ShaderGraph>>();
			BoolParameters = new List<BoolShaderParameter>();
			VectorParameters = new List<VectorShaderParameter>();
			VectorArrayParameters = new List<VectorArrayShaderParameter>();
			TextureParameters = new List<TextureShaderParameter>();
		}
	}
}
