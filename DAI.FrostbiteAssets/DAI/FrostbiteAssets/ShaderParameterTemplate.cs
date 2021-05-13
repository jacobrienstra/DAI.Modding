using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ShaderParameterTemplate : DataContainer
	{
		[FieldOffset(8, 24)]
		public string ParameterName { get; set; }

		[FieldOffset(12, 32)]
		public MorphSliderType Category { get; set; }
	}
}
