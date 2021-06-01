using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class TerrainShaderParameter : LinkObject
	{
		[FieldOffset(0, 0)]
		public uint ParameterHandle { get; set; }

		[FieldOffset(4, 4)]
		public TerrainShaderParameterDataType ParameterType { get; set; }

		[FieldOffset(8, 8)]
		public string ParameterName { get; set; }
	}
}
