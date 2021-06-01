namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class IrReverbControllerNodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public AudioGraphNodePort Reverb0 { get; set; }

		[FieldOffset(16, 80)]
		public AudioGraphNodePort Amplitude0 { get; set; }

		[FieldOffset(24, 112)]
		public AudioGraphNodePort Reverb1 { get; set; }

		[FieldOffset(32, 144)]
		public AudioGraphNodePort Amplitude1 { get; set; }

		[FieldOffset(40, 176)]
		public bool NormalizeGain { get; set; }
	}
}
