using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class RandomDelayEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public float MinDelay { get; set; }

		[FieldOffset(20, 100)]
		public float MaxDelay { get; set; }

		[FieldOffset(24, 104)]
		public Realm Realm { get; set; }

		[FieldOffset(28, 108)]
		public TimeDeltaType TimeDeltaType { get; set; }

		[FieldOffset(32, 112)]
		public bool AutoStart { get; set; }

		[FieldOffset(33, 113)]
		public bool RunOnce { get; set; }

		[FieldOffset(34, 114)]
		public bool TrueRandom { get; set; }
	}
}
