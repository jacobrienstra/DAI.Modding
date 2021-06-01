using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BaseMaterial : StackedItemAsset
	{
		[FieldOffset(104, 304)]
		public List<ShaderParameterVector> ShaderParams { get; set; }

		[FieldOffset(108, 312)]
		public List<TextureShaderParameter> TextureParams { get; set; }

		public BaseMaterial()
		{
			ShaderParams = new List<ShaderParameterVector>();
			TextureParams = new List<TextureShaderParameter>();
		}
	}
}
