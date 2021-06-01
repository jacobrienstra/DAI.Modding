namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UITextureAtlasSubAtlas : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<MultiTextureAtlasResult> PipelineResult { get; set; }
	}
}
