using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class TonemapComponentData : VisualEnvironmentComponentData
	{
		[FieldOffset(112, 192)]
		public Vec3 BloomScale { get; set; }

		[FieldOffset(128, 208)]
		public Realm Realm { get; set; }

		[FieldOffset(132, 212)]
		public TonemapMethod TonemapMethod { get; set; }

		[FieldOffset(136, 216)]
		public float MiddleGray { get; set; }

		[FieldOffset(140, 220)]
		public float MinExposure { get; set; }

		[FieldOffset(144, 224)]
		public float MaxExposure { get; set; }

		[FieldOffset(148, 228)]
		public float ExposureAdjustTime { get; set; }

		[FieldOffset(152, 232)]
		public float ChromostereopsisScale { get; set; }

		[FieldOffset(156, 236)]
		public float ChromostereopsisOffset { get; set; }

		[FieldOffset(160, 240)]
		public bool NoLatencyExposure { get; set; }

		[FieldOffset(161, 241)]
		public bool ChromostereopsisEnable { get; set; }
	}
}
