namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UINodeData : DataContainer
	{
		[FieldOffset(8, 24)]
		public string Name { get; set; }

		[FieldOffset(12, 32)]
		public ExternalObject<UIGraphAsset> ParentGraph { get; set; }

		[FieldOffset(16, 40)]
		public bool IsRootNode { get; set; }

		[FieldOffset(17, 41)]
		public bool ParentIsScreen { get; set; }
	}
}
