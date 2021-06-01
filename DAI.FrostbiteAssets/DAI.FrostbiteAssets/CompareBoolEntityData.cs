using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CompareBoolEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 100)]
		public bool Bool { get; set; }

		[FieldOffset(21, 101)]
		public bool TriggerOnPropertyChange { get; set; }

		[FieldOffset(22, 102)]
		public bool TriggerOnStart { get; set; }

		[FieldOffset(23, 103)]
		public bool AlwaysSend { get; set; }
	}
}
