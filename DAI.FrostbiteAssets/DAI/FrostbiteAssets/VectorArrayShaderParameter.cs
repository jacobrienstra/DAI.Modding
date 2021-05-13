using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class VectorArrayShaderParameter : LinkObject
	{
		[FieldOffset(0, 0)]
		public string ParameterName { get; set; }

		[FieldOffset(4, 8)]
		public ShaderParameterType ParameterType { get; set; }

		[FieldOffset(8, 16)]
		public List<Vec4> Values { get; set; }

		public VectorArrayShaderParameter()
		{
			Values = new List<Vec4>();
		}
	}
}
