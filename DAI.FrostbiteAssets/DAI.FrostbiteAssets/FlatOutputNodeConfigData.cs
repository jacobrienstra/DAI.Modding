namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FlatOutputNodeConfigData : OutputNodeConfigData
	{
		[FieldOffset(52, 96)]
		public float WorldAngle { get; set; }

		[FieldOffset(56, 100)]
		public float Angle { get; set; }

		[FieldOffset(60, 104)]
		public AudioCurve ReverbAttenuationCurve { get; set; }

		[FieldOffset(68, 120)]
		public float ReverbGain { get; set; }

		[FieldOffset(72, 124)]
		public bool IsWorldAligned { get; set; }
	}
}
