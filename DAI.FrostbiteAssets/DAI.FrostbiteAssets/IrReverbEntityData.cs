using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class IrReverbEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public ExternalObject<ImpulseResponseAsset> ImpulseResponse { get; set; }

		[FieldOffset(20, 104)]
		public float Gain { get; set; }

		[FieldOffset(24, 108)]
		public float Volume { get; set; }

		[FieldOffset(28, 112)]
		public FadeCurveType FadeCurve { get; set; }

		[FieldOffset(32, 116)]
		public bool IsDominant { get; set; }
	}
}
