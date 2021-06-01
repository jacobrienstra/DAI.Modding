using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UISlotCircleCompData : UIComponentData
	{
		[FieldOffset(32, 136)]
		public List<SlotCircleSlotData> SlotData { get; set; }

		public UISlotCircleCompData()
		{
			SlotData = new List<SlotCircleSlotData>();
		}
	}
}
