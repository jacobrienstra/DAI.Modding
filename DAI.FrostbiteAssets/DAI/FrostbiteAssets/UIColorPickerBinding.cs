namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class UIColorPickerBinding : UIDataBinding
	{
		[FieldOffset(8, 24)]
		public UIDataSourceInfo ColorData { get; set; }

		[FieldOffset(32, 64)]
		public Vec3 DefaultColor { get; set; }
	}
}
