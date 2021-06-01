namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class JumpNode : UINodeData
	{
		[FieldOffset(20, 64)]
		public ExternalObject<UINodePort> In { get; set; }

		[FieldOffset(24, 72)]
		public ExternalObject<UINodeData> TargetNode { get; set; }

		[FieldOffset(28, 80)]
		public ExternalObject<UINodePort> TargetPort { get; set; }
	}
}
