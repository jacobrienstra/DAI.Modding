using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class GetLocalizedStringIDData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 104)]
		public LocalizedStringReference Text { get; set; }

		[FieldOffset(24, 128)]
		public int StringIDOverride { get; set; }
	}
}
