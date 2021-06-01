using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCounterEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 100)]
		public int DefaultValue { get; set; }

		[FieldOffset(24, 104)]
		public int IncDecValue { get; set; }

		[FieldOffset(28, 108)]
		public int MinCount { get; set; }

		[FieldOffset(32, 112)]
		public int MaxCount { get; set; }
	}
}
