using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UISettingsPage : LinkObject
	{
		[FieldOffset(0, 0)]
		public string NameSid { get; set; }

		[FieldOffset(4, 8)]
		public List<UISettingsGroup> SettingsGroups { get; set; }

		public UISettingsPage()
		{
			SettingsGroups = new List<UISettingsGroup>();
		}
	}
}
