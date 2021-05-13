using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class UpdateBeamPointData : ProcessorData
	{
		[FieldOffset(16, 64)]
		public Vec4 TaperCoefficients { get; set; }

		[FieldOffset(32, 80)]
		public Vec4 AttractorCoefficients { get; set; }

		[FieldOffset(48, 96)]
		public Vec4 ParamCoefficients { get; set; }

		[FieldOffset(64, 112)]
		public uint NumPoints { get; set; }

		[FieldOffset(68, 116)]
		public LocationSelection Attractor { get; set; }

		[FieldOffset(72, 120)]
		public ParamOverrideSelection ParamOverride { get; set; }
	}
}
