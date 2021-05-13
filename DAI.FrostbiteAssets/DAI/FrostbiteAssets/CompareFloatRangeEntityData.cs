using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CompareFloatRangeEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 100)]
		public float Value { get; set; }

		[FieldOffset(24, 104)]
		public float Min { get; set; }

		[FieldOffset(28, 108)]
		public float Max { get; set; }

		[FieldOffset(32, 112)]
		public bool TriggerOnPropertyChange { get; set; }

		[FieldOffset(33, 113)]
		public bool TriggerOnStart { get; set; }

		[FieldOffset(34, 114)]
		public bool AlwaysSend { get; set; }
	}
}
