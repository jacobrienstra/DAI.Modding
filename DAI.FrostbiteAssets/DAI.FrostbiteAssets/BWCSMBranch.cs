using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMBranch : BWCSMTimelineEvent
	{
		[FieldOffset(24, 64)]
		public float Editor_PreviewThisBranchPercent { get; set; }

		[FieldOffset(28, 72)]
		public ExternalObject<BWCSMStateBase> BranchState { get; set; }

		[FieldOffset(32, 80)]
		public float StateStartOffset { get; set; }

		[FieldOffset(36, 84)]
		public float BlendIn { get; set; }

		[FieldOffset(40, 88)]
		public BWCSMStateBlendType BlendInType { get; set; }

		[FieldOffset(44, 96)]
		public AntRef DofWeightCurves { get; set; }

		[FieldOffset(64, 144)]
		public BWCSM_BranchType BranchType { get; set; }

		[FieldOffset(68, 148)]
		public float RandomChance { get; set; }

		[FieldOffset(72, 152)]
		public bool Editor_PreviewThisBranch { get; set; }

		[FieldOffset(73, 153)]
		public byte BranchPriority { get; set; }

		[FieldOffset(74, 154)]
		public bool SyncStateTime { get; set; }

		[FieldOffset(75, 155)]
		public bool CustomBlend { get; set; }

		[FieldOffset(76, 156)]
		public bool AIDecision { get; set; }

		[FieldOffset(77, 157)]
		public bool UsePartnerFromImpact { get; set; }
	}
}
