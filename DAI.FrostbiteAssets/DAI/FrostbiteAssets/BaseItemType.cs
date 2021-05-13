namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BaseItemType : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public LocalizedStringReference DisplayName { get; set; }

		[FieldOffset(16, 96)]
		public UITextureAtlasTextureReference TypeIcon { get; set; }

		[FieldOffset(36, 136)]
		public ExternalObject<CinebotItemCameraSettings> ItemCameraSettings { get; set; }

		[FieldOffset(40, 144)]
		public uint NameHash { get; set; }

		[FieldOffset(44, 148)]
		public bool SupportsPartyMemberVariations { get; set; }
	}
}
