namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIMultiplayerArchetypeTextureData : LinkObject
	{
		[FieldOffset(0, 0)]
		public int HubArchetypeID { get; set; }

		[FieldOffset(4, 8)]
		public ExternalObject<TextureAsset> LockedCardImage { get; set; }
	}
}
