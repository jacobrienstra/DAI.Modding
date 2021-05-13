using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class ShaderParameterEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Vec4 VecParam { get; set; }

		[FieldOffset(32, 112)]
		public uint ParameterHandle { get; set; }

		[FieldOffset(36, 116)]
		public ShaderParameterDataType ParameterType { get; set; }

		[FieldOffset(40, 120)]
		public bool BoolParam { get; set; }
	}
}
