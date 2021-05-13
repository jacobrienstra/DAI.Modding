using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_TimeDilation : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public float RealTimeDurationOverride { get; set; }

		[FieldOffset(32, 76)]
		public float FadeInTime { get; set; }

		[FieldOffset(36, 80)]
		public float FadeOutTime { get; set; }

		[FieldOffset(40, 84)]
		public DilationPriority Priority { get; set; }

		[FieldOffset(44, 88)]
		public float DilationValue { get; set; }

		[FieldOffset(48, 92)]
		public TimeDeltaType TimeDeltaType { get; set; }

		[FieldOffset(52, 96)]
		public uint OverrideID { get; set; }

		[FieldOffset(56, 100)]
		public uint UniqueId { get; set; }
	}
}
