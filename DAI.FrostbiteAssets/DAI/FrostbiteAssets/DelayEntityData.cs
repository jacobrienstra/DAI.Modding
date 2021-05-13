using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DelayEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public float Delay { get; set; }

		[FieldOffset(20, 100)]
		public Realm Realm { get; set; }

		[FieldOffset(24, 104)]
		public TimeDeltaType TimeDeltaType { get; set; }

		[FieldOffset(28, 108)]
		public bool AutoStart { get; set; }

		[FieldOffset(29, 109)]
		public bool RunOnce { get; set; }

		[FieldOffset(30, 110)]
		public bool RemoveDuplicateEvents { get; set; }
	}
}
