using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class InteractableComponentData : GameComponentData
	{
		[FieldOffset(96, 176)]
		public BWInteractionType InteractionType { get; set; }

		[FieldOffset(100, 180)]
		public int OverrideInteractionStringID { get; set; }

		[FieldOffset(104, 184)]
		public LocalizedStringReference InteractionTextReference { get; set; }

		[FieldOffset(108, 208)]
		public float UseWithinRadius { get; set; }

		[FieldOffset(112, 212)]
		public float UseWithinAngle { get; set; }

		[FieldOffset(116, 216)]
		public uint MaxUses { get; set; }

		[FieldOffset(120, 220)]
		public float DisplayWithinRadius { get; set; }

		[FieldOffset(124, 224)]
		public int InputAction { get; set; }

		[FieldOffset(128, 228)]
		public float HoldToInteractTime { get; set; }

		[FieldOffset(132, 232)]
		public bool Enabled { get; set; }

		[FieldOffset(133, 233)]
		public bool UseDisplayWithinRadius { get; set; }

		[FieldOffset(134, 234)]
		public bool TestIfOccluded { get; set; }

		[FieldOffset(135, 235)]
		public bool AllowMultipleSimultaneousInteractions { get; set; }
	}
}
