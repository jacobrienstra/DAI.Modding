using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SlotSoundActionList : Asset
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<SlotSoundAction>> SlotList { get; set; }

		public SlotSoundActionList()
		{
			SlotList = new List<ExternalObject<SlotSoundAction>>();
		}
	}
}
