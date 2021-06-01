using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWNotePopupEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 104)]
		public LocalizedStringReference Title { get; set; }

		[FieldOffset(24, 128)]
		public LocalizedStringReference Body { get; set; }
	}
}
