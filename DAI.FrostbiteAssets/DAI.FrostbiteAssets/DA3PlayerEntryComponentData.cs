using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class DA3PlayerEntryComponentData : PlayerEntryComponentData
	{
		[FieldOffset(224, 352)]
		public List<DA3PlayerEntryInputEvent> EntryInputEvents { get; set; }

		public DA3PlayerEntryComponentData()
		{
			EntryInputEvents = new List<DA3PlayerEntryInputEvent>();
		}
	}
}
