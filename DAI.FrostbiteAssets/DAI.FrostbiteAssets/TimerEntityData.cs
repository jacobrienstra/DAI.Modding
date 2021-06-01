using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class TimerEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 100)]
		public UpdatePass UpdatePass { get; set; }

		[FieldOffset(24, 104)]
		public TimerDirection DefaultDirection { get; set; }

		[FieldOffset(28, 108)]
		public float Min { get; set; }

		[FieldOffset(32, 112)]
		public float Max { get; set; }

		[FieldOffset(36, 116)]
		public float StartTime { get; set; }

		[FieldOffset(40, 120)]
		public float JumpTime { get; set; }

		[FieldOffset(44, 124)]
		public float Speed { get; set; }

		[FieldOffset(48, 128)]
		public TimeDeltaType TimeDeltaType { get; set; }

		[FieldOffset(52, 132)]
		public bool AutoPlay { get; set; }

		[FieldOffset(53, 133)]
		public bool RestartOnGoal { get; set; }

		[FieldOffset(54, 134)]
		public bool Looping { get; set; }
	}
}
