namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class OutputNodeConfigData : AudioGraphNodeConfigData
	{
		[FieldOffset(12, 32)]
		public float MinDistance { get; set; }

		[FieldOffset(16, 40)]
		public AudioCurve AttenuationCurve { get; set; }

		[FieldOffset(24, 56)]
		public float HFDampingDistance { get; set; }

		[FieldOffset(28, 60)]
		public float HFDampingObstruction { get; set; }

		[FieldOffset(32, 64)]
		public float HFDampingOcclusion { get; set; }

		[FieldOffset(36, 68)]
		public float Gain { get; set; }

		[FieldOffset(40, 72)]
		public float ExpectedPeakAmplitude { get; set; }

		[FieldOffset(44, 80)]
		public ExternalObject<MixGroup> MixGroup { get; set; }

		[FieldOffset(48, 88)]
		public bool EnableHdr { get; set; }
	}
}
