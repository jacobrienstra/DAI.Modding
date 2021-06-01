using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UISettingsGroup : LinkObject
	{
		[FieldOffset(0, 0)]
		public string NameSid { get; set; }

		[FieldOffset(4, 8)]
		public int ScreenColumn { get; set; }

		[FieldOffset(8, 16)]
		public List<UISettingsItem> SettingsItems { get; set; }

		public UISettingsGroup()
		{
			SettingsItems = new List<UISettingsItem>();
		}
	}
}
