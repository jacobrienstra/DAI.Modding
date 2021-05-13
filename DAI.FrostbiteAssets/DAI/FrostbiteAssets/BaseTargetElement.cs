namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BaseTargetElement : DataContainer
	{
		[FieldOffset(8, 24)]
		public int BoneId { get; set; }

		[FieldOffset(12, 28)]
		public float Radius { get; set; }

		[FieldOffset(16, 32)]
		public Vec3 RotationOffset { get; set; }

		[FieldOffset(32, 48)]
		public Vec3 PositionOffset { get; set; }

		[FieldOffset(48, 64)]
		public LocalizedStringReference TargetNameReference { get; set; }

		[FieldOffset(52, 88)]
		public int TargetIndex { get; set; }

		[FieldOffset(56, 92)]
		public bool StartDisabled { get; set; }

		[FieldOffset(57, 93)]
		public bool StartCombatDisabled { get; set; }

		[FieldOffset(58, 94)]
		public bool GlobalTarget { get; set; }
	}
}
