using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UISettingsCompData : UIComponentData
	{
		[FieldOffset(32, 136)]
		public LocalizedStringReference DuplicateBindingConfirmationString { get; set; }

		[FieldOffset(36, 160)]
		public LocalizedStringReference ConfirmString { get; set; }

		[FieldOffset(40, 184)]
		public LocalizedStringReference BackString { get; set; }

		[FieldOffset(44, 208)]
		public List<UISettingsPage> SettingsPages { get; set; }

		[FieldOffset(48, 216)]
		public bool RequiresPlayer { get; set; }

		public UISettingsCompData()
		{
			SettingsPages = new List<UISettingsPage>();
		}
	}
}
