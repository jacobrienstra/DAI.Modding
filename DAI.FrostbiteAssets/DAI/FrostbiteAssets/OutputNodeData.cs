using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class OutputNodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public AudioGraphNodePort In { get; set; }

		[FieldOffset(16, 80)]
		public AudioGraphNodePort BypassHeadroom { get; set; }

		[FieldOffset(24, 112)]
		public float MinDistance { get; set; }

		[FieldOffset(28, 120)]
		public AudioCurve AttenuationCurve { get; set; }

		[FieldOffset(36, 136)]
		public float HFDampingDistance { get; set; }

		[FieldOffset(40, 140)]
		public float HFDampingObstruction { get; set; }

		[FieldOffset(44, 144)]
		public float HFDampingOcclusion { get; set; }

		[FieldOffset(48, 148)]
		public LowPassFilterType HFDampingRuntimeFilter { get; set; }

		[FieldOffset(52, 152)]
		public float Gain { get; set; }

		[FieldOffset(56, 160)]
		public ExternalObject<BusNodeData> MainSend { get; set; }

		[FieldOffset(60, 168)]
		public float ExpectedPeakAmplitude { get; set; }

		[FieldOffset(64, 172)]
		public OutputTransformSource TransformSource { get; set; }

		[FieldOffset(68, 176)]
		public string OutputName { get; set; }

		[FieldOffset(72, 184)]
		public uint OutputNameHash { get; set; }

		[FieldOffset(76, 192)]
		public ExternalObject<MixGroup> MixGroup { get; set; }

		[FieldOffset(80, 200)]
		public bool Solo { get; set; }

		[FieldOffset(81, 201)]
		public bool EnableHdr { get; set; }

		[FieldOffset(82, 202)]
		public SoundGraphPluginRef LowPassPlugin { get; set; }

		[FieldOffset(85, 205)]
		public SoundGraphPluginRef VuPlugin { get; set; }

		[FieldOffset(88, 208)]
		public SoundGraphPluginRef MainSendPlugin { get; set; }
	}
}
