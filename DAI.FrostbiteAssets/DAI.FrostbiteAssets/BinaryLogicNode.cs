namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BinaryLogicNode : UINodeData
	{
		[FieldOffset(20, 64)]
		public ExternalObject<UINodePort> In { get; set; }

		[FieldOffset(24, 72)]
		public ExternalObject<UINodePort> True { get; set; }

		[FieldOffset(28, 80)]
		public ExternalObject<UINodePort> False { get; set; }

		[FieldOffset(32, 88)]
		public UISimpleDataSource DataSourceInfo { get; set; }
	}
}
