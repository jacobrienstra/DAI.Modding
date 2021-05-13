namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AudioGraphNodeConfigData : DataContainer
	{
		[FieldOffset(8, 24)]
		public ExternalObject<AudioGraphNodeData> Node { get; set; }
	}
}
