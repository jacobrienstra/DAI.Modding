using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWSetDataValueToTextureAssetPathEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 104)]
		public string TextureAssetPath { get; set; }

		[FieldOffset(24, 112)]
		public UIDataSourceInfo DataSource { get; set; }
	}
}
