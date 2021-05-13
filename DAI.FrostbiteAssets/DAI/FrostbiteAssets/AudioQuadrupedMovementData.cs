namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AudioQuadrupedMovementData : AudioMovementData
	{
		[FieldOffset(12, 72)]
		public AntRef FootPlantingPointerAsset { get; set; }

		[FieldOffset(32, 120)]
		public ExternalObject<Dummy> BodyFall { get; set; }

		[FieldOffset(36, 128)]
		public ExternalObject<SoundAsset> Movement { get; set; }

		[FieldOffset(40, 136)]
		public ExternalObject<SoundAsset> FrontLeftFoot { get; set; }

		[FieldOffset(44, 144)]
		public ExternalObject<SoundAsset> FrontRightFoot { get; set; }

		[FieldOffset(48, 152)]
		public ExternalObject<SoundAsset> RearLeftFoot { get; set; }

		[FieldOffset(52, 160)]
		public ExternalObject<SoundAsset> RearRightFoot { get; set; }

		[FieldOffset(56, 168)]
		public ExternalObject<AudioMovementTrackedBoneData> FrontLeftFootData { get; set; }

		[FieldOffset(60, 176)]
		public ExternalObject<AudioMovementTrackedBoneData> FrontRightFootData { get; set; }

		[FieldOffset(64, 184)]
		public ExternalObject<AudioMovementTrackedBoneData> RearLeftFootData { get; set; }

		[FieldOffset(68, 192)]
		public ExternalObject<AudioMovementTrackedBoneData> RearRightFootData { get; set; }

		[FieldOffset(72, 200)]
		public float VelocityTolerance { get; set; }
	}
}
