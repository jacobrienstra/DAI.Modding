using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MasterUnitNodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public AudioGraphNodePort SettingsIndex { get; set; }

		[FieldOffset(16, 80)]
		public AudioGraphNodePort Amplitude { get; set; }

		[FieldOffset(24, 112)]
		public AudioGraphNodePort MasterGain { get; set; }

		[FieldOffset(32, 144)]
		public AudioGraphNodePort MasterLfeGain { get; set; }

		[FieldOffset(40, 176)]
		public AudioGraphNodePort MasterDialogGain { get; set; }

		[FieldOffset(48, 208)]
		public AudioGraphNodePort SfxGain { get; set; }

		[FieldOffset(56, 240)]
		public AudioGraphNodePort ParallelCompressionGain { get; set; }

		[FieldOffset(64, 272)]
		public AudioGraphNodePort ReverbGain { get; set; }

		[FieldOffset(72, 304)]
		public AudioGraphNodePort CleanSignalGain { get; set; }

		[FieldOffset(80, 336)]
		public AudioGraphNodePort HighPassFreq { get; set; }

		[FieldOffset(88, 368)]
		public AudioGraphNodePort LowShelfFreq { get; set; }

		[FieldOffset(96, 400)]
		public AudioGraphNodePort LowShelfGain { get; set; }

		[FieldOffset(104, 432)]
		public AudioGraphNodePort HighShelfFreq { get; set; }

		[FieldOffset(112, 464)]
		public AudioGraphNodePort HighShelfGain { get; set; }

		[FieldOffset(120, 496)]
		public AudioGraphNodePort CompThreshold { get; set; }

		[FieldOffset(128, 528)]
		public AudioGraphNodePort CompRatio { get; set; }

		[FieldOffset(136, 560)]
		public AudioGraphNodePort CompAttack { get; set; }

		[FieldOffset(144, 592)]
		public AudioGraphNodePort CompRelease { get; set; }

		[FieldOffset(152, 624)]
		public AudioGraphNodePort DistClipLevel { get; set; }

		[FieldOffset(160, 656)]
		public AudioGraphNodePort ParallelDistortionGain { get; set; }

		[FieldOffset(168, 688)]
		public List<ExternalObject<BusNodeData>> Settings { get; set; }

		public MasterUnitNodeData()
		{
			Settings = new List<ExternalObject<BusNodeData>>();
		}
	}
}
