namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UISlotGridDataBinding : UIDataBinding
	{
		[FieldOffset(8, 24)]
		public UIDataSourceInfo UISlotGridContent { get; set; }
	}
}
