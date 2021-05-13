using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class VectorShaderParameter : LinkObject
	{
		[FieldOffset(0, 0)]
		public Vec4 Value { get; set; }

		[FieldOffset(16, 16)]
		public string ParameterName { get; set; }

		[FieldOffset(20, 24)]
		public ShaderParameterType ParameterType { get; set; }
	}
}
