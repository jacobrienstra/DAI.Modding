namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIMultiplayerPickerBinding : UIDataBinding
	{
		[FieldOffset(8, 24)]
		public LocalizedStringReference HeaderText { get; set; }
	}
}
