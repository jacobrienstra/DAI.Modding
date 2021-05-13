using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DA3MPItemSlot : LinkObject
	{
		[FieldOffset(0, 0)]
		public int SlotId { get; set; }

		[FieldOffset(4, 4)]
		public uint ItemId { get; set; }

		[FieldOffset(8, 8)]
		public List<DA3MPRestrictionList> RestrictionLists { get; set; }

		[FieldOffset(12, 16)]
		public int SlotType { get; set; }

		[FieldOffset(16, 20)]
		public int SlotCount { get; set; }

		public DA3MPItemSlot()
		{
			RestrictionLists = new List<DA3MPRestrictionList>();
		}
	}
}
