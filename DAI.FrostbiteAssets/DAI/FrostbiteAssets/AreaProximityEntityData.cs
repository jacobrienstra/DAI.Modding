using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AreaProximityEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 100)]
		public UpdatePass UpdatePass { get; set; }

		[FieldOffset(24, 104)]
		public float ProximityDistance { get; set; }

		[FieldOffset(28, 108)]
		public bool AutoStart { get; set; }
	}
}
