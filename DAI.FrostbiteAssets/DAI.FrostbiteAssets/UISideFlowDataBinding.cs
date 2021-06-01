namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UISideFlowDataBinding : BWListFlowBinding
	{
		[FieldOffset(56, 120)]
		public bool StickNavigation { get; set; }

		[FieldOffset(57, 121)]
		public bool ShowNavigationIcons { get; set; }
	}
}
