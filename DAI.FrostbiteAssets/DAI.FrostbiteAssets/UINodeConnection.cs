namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UINodeConnection : DataContainer
	{
		[FieldOffset(8, 24)]
		public ExternalObject<UINodeData> SourceNode { get; set; }

		[FieldOffset(12, 32)]
		public ExternalObject<UINodeData> TargetNode { get; set; }

		[FieldOffset(16, 40)]
		public ExternalObject<UINodePort> SourcePort { get; set; }

		[FieldOffset(20, 48)]
		public ExternalObject<UINodePort> TargetPort { get; set; }

		[FieldOffset(24, 56)]
		public string SourcePortName { get; set; }

		[FieldOffset(28, 64)]
		public string TargetPortName { get; set; }

		[FieldOffset(32, 72)]
		public int NumScreensToPop { get; set; }
	}
}
