namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BoomArmTransposerData : CinebotTransposerData
	{
		[FieldOffset(28, 120)]
		public string AnchorPart { get; set; }

		[FieldOffset(32, 128)]
		public Vec3 Pivot { get; set; }

		[FieldOffset(48, 144)]
		public float ArmLength { get; set; }

		[FieldOffset(52, 152)]
		public ExternalObject<CinebotLocatorIdentifierAsset> CinebotLocatorIdentifier { get; set; }

		[FieldOffset(56, 160)]
		public int PitchControl { get; set; }

		[FieldOffset(60, 164)]
		public int YawControl { get; set; }

		[FieldOffset(64, 168)]
		public float YawSpeed { get; set; }

		[FieldOffset(68, 172)]
		public float PitchSpeed { get; set; }

		[FieldOffset(72, 176)]
		public float MaxPitch { get; set; }

		[FieldOffset(76, 180)]
		public float MinPitch { get; set; }

		[FieldOffset(80, 184)]
		public float DefaultPitch { get; set; }

		[FieldOffset(84, 188)]
		public float DefaultYaw { get; set; }

		[FieldOffset(88, 192)]
		public bool UseInputFromPlayer { get; set; }

		[FieldOffset(89, 193)]
		public bool EnableDefaultPitch { get; set; }

		[FieldOffset(90, 194)]
		public bool EnableDefaultYaw { get; set; }
	}
}
