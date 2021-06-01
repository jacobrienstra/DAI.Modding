namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class GroundRingConfigurationAsset : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public ExternalObject<EffectBlueprint> DefaultPartyMemberEffect { get; set; }

		[FieldOffset(16, 80)]
		public ExternalObject<EffectBlueprint> SelectedPartyMemberEffect { get; set; }

		[FieldOffset(20, 88)]
		public ExternalObject<EffectBlueprint> TargetedPartyMemberEffect { get; set; }

		[FieldOffset(24, 96)]
		public ExternalObject<EffectBlueprint> NontargetedHostileEffect { get; set; }

		[FieldOffset(28, 104)]
		public ExternalObject<EffectBlueprint> TargetedHostileEffect { get; set; }

		[FieldOffset(32, 112)]
		public ExternalObject<EffectBlueprint> NontargetedAllyEffect { get; set; }

		[FieldOffset(36, 120)]
		public ExternalObject<EffectBlueprint> TargetedAllyEffect { get; set; }
	}
}
