using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SlotCircleSlotData : LinkObject
	{
		[FieldOffset(0, 0)]
		public uint SlotSnapAngleDegrees { get; set; }

		[FieldOffset(4, 8)]
		public List<uint> SlotAngles { get; set; }

		public SlotCircleSlotData()
		{
			SlotAngles = new List<uint>();
		}
	}
}
