using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class TextureShaderParameterTemplate : ShaderParameterTemplate
	{
		[FieldOffset(16, 40)]
		public List<TextureContainer> TextureList { get; set; }

		[FieldOffset(20, 48)]
		public string PresentationName { get; set; }

		public TextureShaderParameterTemplate()
		{
			TextureList = new List<TextureContainer>();
		}
	}
}
