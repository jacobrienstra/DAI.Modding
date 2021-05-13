namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIBinaryChoiceBinding : UIDataBinding
	{
		[FieldOffset(8, 24)]
		public UIDataSourceInfo BinaryChoiceData { get; set; }

		[FieldOffset(24, 56)]
		public string ScreenItemType { get; set; }
	}
}
