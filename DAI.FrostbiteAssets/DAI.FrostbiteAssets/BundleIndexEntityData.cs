using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BundleIndexEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 104)]
		public ExternalObject<CharacterBlueprintBundleIndexMapItemAsset> BundleIndices { get; set; }
	}
}
