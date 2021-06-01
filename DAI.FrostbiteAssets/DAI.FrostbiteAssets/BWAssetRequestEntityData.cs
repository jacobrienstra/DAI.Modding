using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWAssetRequestEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 104)]
		public string Request { get; set; }

		[FieldOffset(24, 112)]
		public AssetRequest Category { get; set; }

		[FieldOffset(28, 116)]
		public bool ShouldDisplay { get; set; }
	}
}
