using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CompareIntRangeEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 100)]
		public int Value { get; set; }

		[FieldOffset(24, 104)]
		public int Min { get; set; }

		[FieldOffset(28, 108)]
		public int Max { get; set; }

		[FieldOffset(32, 112)]
		public bool TriggerOnPropertyChange { get; set; }

		[FieldOffset(33, 113)]
		public bool TriggerOnStart { get; set; }

		[FieldOffset(34, 114)]
		public bool AlwaysSend { get; set; }
	}
}
