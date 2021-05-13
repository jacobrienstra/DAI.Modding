using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class SliderShaderParameterTemplate : ShaderParameterTemplate
	{
		[FieldOffset(16, 48)]
		public Vec4 Default { get; set; }

		[FieldOffset(32, 64)]
		public float Min { get; set; }

		[FieldOffset(36, 68)]
		public float Max { get; set; }

		[FieldOffset(40, 72)]
		public float Step { get; set; }

		[FieldOffset(44, 76)]
		public VectorShaderNumValuesUsed ValuesUsed { get; set; }

		[FieldOffset(48, 80)]
		public string PresentationNameX { get; set; }

		[FieldOffset(52, 88)]
		public string PresentationNameY { get; set; }

		[FieldOffset(56, 96)]
		public string PresentationNameZ { get; set; }

		[FieldOffset(60, 104)]
		public string PresentationNameW { get; set; }
	}
}
