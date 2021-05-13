namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class KeepAliveNodeData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public AudioGraphNodePort KeepAlive { get; set; }
	}
}
