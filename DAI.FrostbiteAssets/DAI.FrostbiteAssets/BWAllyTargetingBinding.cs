namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWAllyTargetingBinding : UIDataBinding
	{
		[FieldOffset(8, 24)]
		public UIDataSourceInfo Exit { get; set; }
	}
}
