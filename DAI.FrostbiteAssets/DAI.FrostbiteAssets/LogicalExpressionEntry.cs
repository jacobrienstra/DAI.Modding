namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LogicalExpressionEntry : AudioGraphNodePortGroup
	{
		[FieldOffset(8, 24)]
		public AudioGraphNodePort Trigger { get; set; }
	}
}
