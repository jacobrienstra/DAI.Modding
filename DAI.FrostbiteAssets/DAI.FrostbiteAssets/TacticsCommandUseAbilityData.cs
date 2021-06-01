using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class TacticsCommandUseAbilityData : TacticsCommandData
	{
		[FieldOffset(16, 96)]
		public TacticsTarget Target { get; set; }

		[FieldOffset(20, 100)]
		public TacticsTarget Prop { get; set; }

		[FieldOffset(24, 104)]
		public ExternalObject<TransformProvider> TargetTransform { get; set; }

		[FieldOffset(28, 112)]
		public ExternalObject<BWActivatedAbility> Ability { get; set; }

		[FieldOffset(32, 120)]
		public BWAbilityTagRef AbilityTag { get; set; }

		[FieldOffset(36, 136)]
		public bool MoveIntoRange { get; set; }
	}
}
