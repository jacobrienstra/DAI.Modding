using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class ConeOutputNodeData : OutputNodeData
	{
		[FieldOffset(92, 216)]
		public AudioGraphNodePort PositionX { get; set; }

		[FieldOffset(100, 248)]
		public AudioGraphNodePort PositionY { get; set; }

		[FieldOffset(108, 280)]
		public AudioGraphNodePort PositionZ { get; set; }

		[FieldOffset(116, 312)]
		public AudioGraphNodePort InnerAngle { get; set; }

		[FieldOffset(124, 344)]
		public AudioGraphNodePort OuterAngle { get; set; }

		[FieldOffset(132, 376)]
		public float OutsideGain { get; set; }

		[FieldOffset(136, 380)]
		public float PanSize { get; set; }

		[FieldOffset(140, 384)]
		public float BleedMinDistance { get; set; }

		[FieldOffset(144, 400)]
		public Vec3 Direction { get; set; }

		[FieldOffset(160, 416)]
		public float BleedMaxDistance { get; set; }

		[FieldOffset(164, 420)]
		public AudioGraphNodePort CenterLevel { get; set; }

		[FieldOffset(172, 452)]
		public AudioGraphNodePort LfeLevel { get; set; }

		[FieldOffset(180, 484)]
		public float HFDampingAngle { get; set; }

		[FieldOffset(184, 488)]
		public AudioCurve ReverbAttenuationCurve { get; set; }

		[FieldOffset(192, 504)]
		public float ReverbGain { get; set; }

		[FieldOffset(196, 508)]
		public OutputReverbMode ReverbMode { get; set; }

		[FieldOffset(200, 512)]
		public ExternalObject<BusNodeData> ReverbSend { get; set; }

		[FieldOffset(204, 520)]
		public SoundGraphPluginRef PanPlugin { get; set; }

		[FieldOffset(207, 523)]
		public SoundGraphPluginRef ReverbSendPlugin { get; set; }
	}
}
