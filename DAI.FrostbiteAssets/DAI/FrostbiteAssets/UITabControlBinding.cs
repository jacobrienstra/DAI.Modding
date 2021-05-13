using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UITabControlBinding : UIDataBinding
	{
		[FieldOffset(8, 24)]
		public UIControlInputType InputType { get; set; }

		[FieldOffset(12, 32)]
		public string TabLinkageID { get; set; }

		[FieldOffset(16, 40)]
		public uint MinimumTabSize { get; set; }

		[FieldOffset(20, 48)]
		public UIDataSourceInfo TabData { get; set; }

		[FieldOffset(36, 80)]
		public UIDataSourceInfo SetSelectedTab { get; set; }

		[FieldOffset(52, 112)]
		public UIDataSourceInfo DefaultSelectedTab { get; set; }

		[FieldOffset(68, 144)]
		public bool EqualSizeTabs { get; set; }

		[FieldOffset(69, 145)]
		public bool IgnoreInvalidTabSelection { get; set; }
	}
}
