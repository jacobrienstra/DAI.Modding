using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class ShaderParamsComponentData : VisualEnvironmentComponentData
	{
		[FieldOffset(112, 192)]
		public Vec4 Value { get; set; }

		[FieldOffset(128, 208)]
		public Realm Realm { get; set; }

		[FieldOffset(132, 216)]
		public string ParameterName { get; set; }
	}
}
