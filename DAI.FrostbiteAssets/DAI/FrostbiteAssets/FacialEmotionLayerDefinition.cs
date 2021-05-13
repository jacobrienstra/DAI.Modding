namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FacialEmotionLayerDefinition : DataContainer
	{
		[FieldOffset(8, 24)]
		public AntRef GameState { get; set; }
	}
}
