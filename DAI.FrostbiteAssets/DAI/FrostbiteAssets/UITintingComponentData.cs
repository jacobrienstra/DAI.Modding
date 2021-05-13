using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UITintingComponentData : UIComponentData
	{
		[FieldOffset(32, 136)]
		public UITextureAtlasTextureReference TintSlotTypeIcon { get; set; }

		[FieldOffset(52, 176)]
		public List<TintingSlot> TintingSlots { get; set; }

		public UITintingComponentData()
		{
			TintingSlots = new List<TintingSlot>();
		}
	}
}
