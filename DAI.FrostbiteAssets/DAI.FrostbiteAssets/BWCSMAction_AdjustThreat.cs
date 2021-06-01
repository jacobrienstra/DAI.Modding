using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_AdjustThreat : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public Delegate_float Value { get; set; }

		[FieldOffset(40, 96)]
		public BWCSMActionTarget ThreatGiver { get; set; }

		[FieldOffset(44, 100)]
		public BWCSMActionTarget ThreatTaker { get; set; }

		[FieldOffset(48, 104)]
		public float ForceHateTime { get; set; }

		[FieldOffset(52, 108)]
		public bool ForceMostHated { get; set; }
	}
}
