using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class GameProjectileMoverSinWavePositionModifierData : GameProjectileLocalSpaceMoverModifierData
	{
		[FieldOffset(12, 32)]
		public AxisMode Axis { get; set; }

		[FieldOffset(16, 36)]
		public float MinMagnitude { get; set; }

		[FieldOffset(20, 40)]
		public float MaxMagnitude { get; set; }

		[FieldOffset(24, 44)]
		public float MinFrequency { get; set; }

		[FieldOffset(28, 48)]
		public float MaxFrequency { get; set; }

		[FieldOffset(32, 52)]
		public float MinPhaseOffset { get; set; }

		[FieldOffset(36, 56)]
		public float MaxPhaseOffset { get; set; }

		[FieldOffset(40, 60)]
		public ReRandomizationMode RandomizeOverTimeMode { get; set; }

		[FieldOffset(44, 64)]
		public GameProjectileModifierEffectMode Mode { get; set; }

		[FieldOffset(48, 68)]
		public MoverModifierInputBasis LocalSpaceBasis { get; set; }
	}
}
