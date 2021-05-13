using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWInteractionData : LinkObject
	{
		[FieldOffset(0, 0)]
		public BWInteractionType InteractionType { get; set; }

		[FieldOffset(4, 8)]
		public string IconLabel { get; set; }

		[FieldOffset(8, 16)]
		public string ButtonLabel { get; set; }

		[FieldOffset(12, 24)]
		public string HoldToInteractButtonLabel { get; set; }

		[FieldOffset(16, 32)]
		public float VerticalOffset { get; set; }

		[FieldOffset(20, 36)]
		public bool UsableInCombat { get; set; }

		[FieldOffset(21, 37)]
		public bool UsableOnFoot { get; set; }

		[FieldOffset(22, 38)]
		public bool UsableOnMount { get; set; }
	}
}
