using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CharacterStatePoseInfo : DataContainer
	{
		[FieldOffset(8, 24)]
		public CharacterPoseType PoseType { get; set; }

		[FieldOffset(12, 28)]
		public float Velocity { get; set; }

		[FieldOffset(16, 32)]
		public float AccelerationGain { get; set; }

		[FieldOffset(20, 36)]
		public float DecelerationGain { get; set; }

		[FieldOffset(24, 40)]
		public float SprintGain { get; set; }

		[FieldOffset(28, 44)]
		public float SprintMultiplier { get; set; }

		[FieldOffset(32, 48)]
		public SpeedModifierData SpeedModifier { get; set; }

		[FieldOffset(48, 64)]
		public float ShallowWaterMultiplier { get; set; }
	}
}
