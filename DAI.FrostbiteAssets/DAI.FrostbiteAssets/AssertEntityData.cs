using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AssertEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 104)]
		public string Text { get; set; }

		[FieldOffset(24, 112)]
		public bool Pass { get; set; }

		[FieldOffset(25, 113)]
		public bool TriggerOnce { get; set; }

		[FieldOffset(26, 114)]
		public bool TriggerOnPassChanged { get; set; }
	}
}
