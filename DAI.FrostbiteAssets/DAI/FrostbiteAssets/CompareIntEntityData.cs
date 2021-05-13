using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CompareIntEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 100)]
		public int A { get; set; }

		[FieldOffset(24, 104)]
		public int B { get; set; }

		[FieldOffset(28, 108)]
		public bool TriggerOnPropertyChange { get; set; }

		[FieldOffset(29, 109)]
		public bool TriggerOnStart { get; set; }

		[FieldOffset(30, 110)]
		public bool AlwaysSend { get; set; }
	}
}
