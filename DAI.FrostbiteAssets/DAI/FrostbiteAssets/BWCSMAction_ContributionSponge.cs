using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_ContributionSponge : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public ExternalObject<BWTweakableFloatProvider> SpongePercent { get; set; }

		[FieldOffset(32, 80)]
		public ContributionDirection DamageDirection { get; set; }

		[FieldOffset(36, 84)]
		public ContributionTarget ContributionTarget { get; set; }

		[FieldOffset(40, 88)]
		public bool IgnoreCaster { get; set; }

		[FieldOffset(41, 89)]
		public bool ApplyOnce { get; set; }
	}
}
