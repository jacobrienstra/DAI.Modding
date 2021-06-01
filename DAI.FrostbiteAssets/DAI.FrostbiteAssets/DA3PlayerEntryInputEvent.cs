using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DA3PlayerEntryInputEvent : LinkObject
	{
		[FieldOffset(0, 0)]
		public uint EventId { get; set; }

		[FieldOffset(4, 4)]
		public int InputAction { get; set; }

		[FieldOffset(8, 8)]
		public DA3PlayerEntryInputEventType EventType { get; set; }

		[FieldOffset(12, 12)]
		public float Time { get; set; }
	}
}
