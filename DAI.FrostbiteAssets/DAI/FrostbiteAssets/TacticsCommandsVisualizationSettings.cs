namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class TacticsCommandsVisualizationSettings : BWGameplaySettings
	{
		[FieldOffset(12, 72)]
		public LocalizedStringReference MoveToPointDescription { get; set; }

		[FieldOffset(16, 96)]
		public UITextureAtlasTextureReference MoveToPointIcon { get; set; }

		[FieldOffset(36, 136)]
		public ExternalObject<EffectBlueprint> MoveToPointEffect { get; set; }

		[FieldOffset(40, 144)]
		public ExternalObject<EffectBlueprint> MoveToPointAckEffect { get; set; }

		[FieldOffset(44, 152)]
		public LocalizedStringReference UseAbilityDescription { get; set; }

		[FieldOffset(48, 176)]
		public LocalizedStringReference ReviveDescription { get; set; }

		[FieldOffset(52, 200)]
		public UITextureAtlasTextureReference ReviveIcon { get; set; }

		[FieldOffset(72, 240)]
		public LocalizedStringReference InteractDescription { get; set; }

		[FieldOffset(76, 264)]
		public UITextureAtlasTextureReference InteractIcon { get; set; }
	}
}
