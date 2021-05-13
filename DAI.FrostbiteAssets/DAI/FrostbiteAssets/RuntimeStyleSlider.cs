using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class RuntimeStyleSlider : LinkObject
	{
		[FieldOffset(0, 0)]
		public string ShaderParameterName { get; set; }

		[FieldOffset(4, 8)]
		public float Value { get; set; }

		[FieldOffset(8, 12)]
		public SliderParameterAffectVectorComponent AffectedVectorComponent { get; set; }
	}
}
