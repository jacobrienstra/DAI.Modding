using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AudioHumanoidMovementData : AudioMovementData
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<SlotSound>> Equipment { get; set; }

		[FieldOffset(16, 80)]
		public float VelocityTolerance { get; set; }

		[FieldOffset(20, 88)]
		public ExternalObject<SoundPatchConfigurationAsset> BodyFall { get; set; }

		[FieldOffset(24, 96)]
		public ExternalObject<Dummy> HandMovement { get; set; }

		[FieldOffset(28, 104)]
		public ExternalObject<AudioMovementTrackedBoneData> LeftHand { get; set; }

		[FieldOffset(32, 112)]
		public ExternalObject<AudioMovementTrackedBoneData> RightHand { get; set; }

		[FieldOffset(36, 120)]
		public ExternalObject<SoundAsset> Footsteps { get; set; }

		[FieldOffset(40, 128)]
		public ExternalObject<AudioMovementTrackedBoneData> LeftFoot { get; set; }

		[FieldOffset(44, 136)]
		public ExternalObject<AudioMovementTrackedBoneData> RightFoot { get; set; }

		[FieldOffset(48, 144)]
		public AntRef FootPlantingPointerAsset { get; set; }

		[FieldOffset(68, 192)]
		public AntRef TraversalEnum { get; set; }

		[FieldOffset(88, 240)]
		public AntRef GroundPitchAsset { get; set; }

		[FieldOffset(108, 288)]
		public AntRef GroundRollAsset { get; set; }

		public AudioHumanoidMovementData()
		{
			Equipment = new List<ExternalObject<SlotSound>>();
		}
	}
}
