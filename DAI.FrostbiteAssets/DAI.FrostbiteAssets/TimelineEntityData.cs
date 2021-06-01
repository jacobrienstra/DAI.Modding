using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class TimelineEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 104)]
		public ExternalObject<TimelineData> TimelineData { get; set; }

		[FieldOffset(24, 112)]
		public UpdatePass ClientUpdatePass { get; set; }

		[FieldOffset(28, 116)]
		public UpdatePass ServerUpdatePass { get; set; }

		[FieldOffset(32, 120)]
		public float BlendInTime { get; set; }

		[FieldOffset(36, 124)]
		public float BlendOutTime { get; set; }

		[FieldOffset(40, 128)]
		public float InitTime { get; set; }

		[FieldOffset(44, 132)]
		public float StartTime { get; set; }

		[FieldOffset(48, 136)]
		public float EndTime { get; set; }

		[FieldOffset(52, 140)]
		public float JumpTime { get; set; }

		[FieldOffset(56, 144)]
		public float PlaybackRate { get; set; }

		[FieldOffset(60, 148)]
		public float ExternalTime { get; set; }

		[FieldOffset(64, 152)]
		public bool AutoPlay { get; set; }

		[FieldOffset(65, 153)]
		public bool UseRealTimeClock { get; set; }

		[FieldOffset(66, 154)]
		public bool UseSimTimeDilation { get; set; }

		[FieldOffset(67, 155)]
		public bool AutoInitConnectedProperties { get; set; }

		[FieldOffset(68, 156)]
		public bool ResetTimeOnStarted { get; set; }

		[FieldOffset(69, 157)]
		public bool AllowAnimationCarryForward { get; set; }

		[FieldOffset(70, 158)]
		public byte RuntimeFramerate { get; set; }

		[FieldOffset(71, 159)]
		public bool Looping { get; set; }

		[FieldOffset(72, 160)]
		public bool Infinite { get; set; }
	}
}
