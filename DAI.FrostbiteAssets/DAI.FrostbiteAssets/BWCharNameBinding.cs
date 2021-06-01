namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCharNameBinding : UIDataBinding
	{
		[FieldOffset(8, 24)]
		public UIDataSourceInfo Value { get; set; }
	}
}
