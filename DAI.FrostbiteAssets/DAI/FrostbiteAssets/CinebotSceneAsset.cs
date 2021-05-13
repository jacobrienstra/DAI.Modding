namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CinebotSceneAsset : Asset
	{
		[FieldOffset(12, 72)]
		public ExternalObject<CinebotDefaultGlobalSceneData> Data { get; set; }
	}
}
