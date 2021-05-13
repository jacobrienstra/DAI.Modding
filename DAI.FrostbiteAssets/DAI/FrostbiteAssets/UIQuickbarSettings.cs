using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIQuickbarSettings : BWGameplaySettings
	{
		[FieldOffset(12, 72)]
		public List<UIQuickbarSlot> Slots { get; set; }

		[FieldOffset(16, 80)]
		public List<UIQuickbarSlot> MPSlots { get; set; }

		public UIQuickbarSettings()
		{
			Slots = new List<UIQuickbarSlot>();
			MPSlots = new List<UIQuickbarSlot>();
		}
	}
}
