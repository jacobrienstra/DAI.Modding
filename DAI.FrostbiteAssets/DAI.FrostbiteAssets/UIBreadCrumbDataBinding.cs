namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIBreadCrumbDataBinding : UIDataBinding
	{
		[FieldOffset(8, 24)]
		public UIDataSourceInfo UIBreadCrumbSource { get; set; }

		[FieldOffset(24, 56)]
		public int Spacing { get; set; }

		[FieldOffset(28, 60)]
		public bool InteractiveCrumbs { get; set; }
	}
}
