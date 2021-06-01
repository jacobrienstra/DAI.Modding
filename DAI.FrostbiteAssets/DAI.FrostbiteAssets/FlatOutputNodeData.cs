using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FlatOutputNodeData : OutputNodeData
	{
		[FieldOffset(92, 216)]
		public float WorldAngle { get; set; }

		[FieldOffset(96, 220)]
		public float Angle { get; set; }

		[FieldOffset(100, 224)]
		public AudioCurve ReverbAttenuationCurve { get; set; }

		[FieldOffset(108, 240)]
		public float ReverbGain { get; set; }

		[FieldOffset(112, 244)]
		public OutputReverbMode ReverbMode { get; set; }

		[FieldOffset(116, 248)]
		public ExternalObject<BusNodeData> ReverbSend { get; set; }

		[FieldOffset(120, 256)]
		public AudioGraphNodePort CenterLevel { get; set; }

		[FieldOffset(128, 288)]
		public AudioGraphNodePort LfeLevel { get; set; }

		[FieldOffset(136, 320)]
		public bool IsWorldAligned { get; set; }

		[FieldOffset(137, 321)]
		public SoundGraphPluginRef PanPlugin { get; set; }

		[FieldOffset(140, 324)]
		public SoundGraphPluginRef ReverbSendPlugin { get; set; }
	}
}
