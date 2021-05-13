namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UITreeFlowBinding : UIDataBinding
	{
		[FieldOffset(8, 24)]
		public UIDataSourceInfo TreeData { get; set; }

		[FieldOffset(24, 56)]
		public string DisplayType { get; set; }

		[FieldOffset(28, 64)]
		public UIDataSourceInfo DefaultDownSelection { get; set; }
	}
}
