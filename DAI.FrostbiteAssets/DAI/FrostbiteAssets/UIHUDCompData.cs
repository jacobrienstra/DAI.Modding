using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIHUDCompData : UIComponentData
	{
		[FieldOffset(32, 136)]
		public List<UIHUDQuickAccessLockData> QuickAccessLockData { get; set; }

		public UIHUDCompData()
		{
			QuickAccessLockData = new List<UIHUDQuickAccessLockData>();
		}
	}
}
