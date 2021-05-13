using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIHUDQuickAccessLockData : LinkObject
	{
		[FieldOffset(0, 0)]
		public GamepadQuickAccess QuickAccessOption { get; set; }

		[FieldOffset(4, 8)]
		public List<HeroMenuItemLockEntry> Locks { get; set; }

		public UIHUDQuickAccessLockData()
		{
			Locks = new List<HeroMenuItemLockEntry>();
		}
	}
}
