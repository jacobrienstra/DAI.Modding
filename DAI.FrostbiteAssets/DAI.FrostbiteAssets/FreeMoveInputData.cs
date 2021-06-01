using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FreeMoveInputData
	{
		[FieldOffset(0, 0)]
		public InputConceptIdentifiers MoveForwardInputConcept { get; set; }

		[FieldOffset(4, 4)]
		public InputConceptIdentifiers MoveSidewaysInputConcept { get; set; }

		[FieldOffset(8, 8)]
		public float MoveSpeedX { get; set; }

		[FieldOffset(12, 12)]
		public float MoveSpeedZ { get; set; }

		[FieldOffset(16, 16)]
		public float FreeMoveRadius { get; set; }

		[FieldOffset(20, 20)]
		public float MaxDistanceFromPlayer { get; set; }

		[FieldOffset(24, 24)]
		public float CursorInterpolationRate { get; set; }

		[FieldOffset(28, 28)]
		public float CursorVerticalInterpolationRate { get; set; }

		[FieldOffset(32, 32)]
		public bool EnableLockToNavGraph { get; set; }
	}
}
