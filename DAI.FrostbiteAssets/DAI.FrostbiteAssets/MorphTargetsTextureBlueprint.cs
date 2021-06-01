namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MorphTargetsTextureBlueprint : Blueprint
	{
		[FieldOffset(32, 176)]
		public ExternalObject<TextureAsset> Texture { get; set; }
	}
}
