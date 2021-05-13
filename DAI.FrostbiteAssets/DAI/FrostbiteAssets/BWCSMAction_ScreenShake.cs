namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWCSMAction_ScreenShake : BWCSMTargetAction
	{
		[FieldOffset(32, 80)]
		public Vec4 Curve { get; set; }

		[FieldOffset(48, 96)]
		public Vec4 PositionalDistanceCurve { get; set; }

		[FieldOffset(64, 112)]
		public float Pitch { get; set; }

		[FieldOffset(68, 116)]
		public float Yaw { get; set; }

		[FieldOffset(72, 120)]
		public float Roll { get; set; }

		[FieldOffset(76, 124)]
		public float X { get; set; }

		[FieldOffset(80, 128)]
		public float Y { get; set; }

		[FieldOffset(84, 132)]
		public float Z { get; set; }

		[FieldOffset(88, 136)]
		public float XFrequency { get; set; }

		[FieldOffset(92, 140)]
		public float YFrequency { get; set; }

		[FieldOffset(96, 144)]
		public float ZFrequency { get; set; }

		[FieldOffset(100, 148)]
		public float Time { get; set; }

		[FieldOffset(104, 152)]
		public ExternalObject<TransformProvider> ShakePosition { get; set; }

		[FieldOffset(108, 160)]
		public float MaxDistance { get; set; }

		[FieldOffset(112, 164)]
		public float ControllerRumbleLow { get; set; }

		[FieldOffset(116, 168)]
		public float ControllerRumbleHigh { get; set; }

		[FieldOffset(120, 172)]
		public bool Always { get; set; }
	}
}
