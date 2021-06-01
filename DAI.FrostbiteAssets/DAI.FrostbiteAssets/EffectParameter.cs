using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EffectParameter : DataContainer
	{
		[FieldOffset(8, 24)]
		public string Name { get; set; }

		[FieldOffset(12, 32)]
		public EffectParameterType ParamType { get; set; }
	}
}
