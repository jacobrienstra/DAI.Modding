namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class GameOptionsManagerEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public ExternalObject<UIGameOptionsItemAsset> RootNode { get; set; }
	}
}
