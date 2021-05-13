namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class ConeOutputNodeConfigData : OutputNodeConfigData
	{
		[FieldOffset(52, 96)]
		public float OutsideGain { get; set; }

		[FieldOffset(56, 100)]
		public float PanSize { get; set; }

		[FieldOffset(60, 104)]
		public float BleedMinDistance { get; set; }

		[FieldOffset(64, 112)]
		public Vec3 Direction { get; set; }

		[FieldOffset(80, 128)]
		public float BleedMaxDistance { get; set; }

		[FieldOffset(84, 132)]
		public float HFDampingAngle { get; set; }

		[FieldOffset(88, 136)]
		public AudioCurve ReverbAttenuationCurve { get; set; }

		[FieldOffset(96, 152)]
		public float ReverbGain { get; set; }
	}
}
