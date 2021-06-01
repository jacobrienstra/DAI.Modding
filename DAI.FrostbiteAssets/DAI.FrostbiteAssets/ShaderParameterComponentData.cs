using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class ShaderParameterComponentData : GameComponentData
	{
		[FieldOffset(96, 176)]
		public uint ShaderTechnique { get; set; }

		[FieldOffset(100, 184)]
		public List<ShaderParameterVector> ShaderParameterVectors { get; set; }

		[FieldOffset(104, 192)]
		public List<ShaderParameterTexture> ShaderParameterTexture { get; set; }

		public ShaderParameterComponentData()
		{
			ShaderParameterVectors = new List<ShaderParameterVector>();
			ShaderParameterTexture = new List<ShaderParameterTexture>();
		}
	}
}
