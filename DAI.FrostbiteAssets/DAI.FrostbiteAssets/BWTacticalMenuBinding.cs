using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWTacticalMenuBinding : UIDataBinding
	{
		[FieldOffset(8, 24)]
		public BWTacticalMenuType MenuType { get; set; }

		[FieldOffset(12, 28)]
		public UIInputAction ToggleMenuInputAction { get; set; }

		[FieldOffset(16, 32)]
		public UIDataSourceInfo HoldOpen { get; set; }

		[FieldOffset(32, 64)]
		public UIDataSourceInfo WheelDirection { get; set; }

		[FieldOffset(48, 96)]
		public UIDataSourceInfo IndexSelected { get; set; }

		[FieldOffset(64, 128)]
		public UIDataSourceInfo MenuData { get; set; }
	}
}
