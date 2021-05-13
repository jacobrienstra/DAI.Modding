using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWAbility : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public LocalizedStringReference AbilityNameReference { get; set; }

		[FieldOffset(16, 96)]
		public LocalizedStringReference AbilityDescriptionReference { get; set; }

		[FieldOffset(20, 120)]
		public List<FloatProviderTokenizedString> AdditionalDescriptors { get; set; }

		[FieldOffset(24, 128)]
		public LocalizedStringReference AbilityTooltipReference { get; set; }

		[FieldOffset(28, 152)]
		public UITextureAtlasTextureReference AbilityIcon { get; set; }

		[FieldOffset(48, 192)]
		public ExternalObject<Dummy> AbilityDescriptionImage { get; set; }

		[FieldOffset(52, 200)]
		public float AbilityDamage { get; set; }

		[FieldOffset(56, 208)]
		public List<BWAbilityDesignerProperty> DesignerProperties { get; set; }

		[FieldOffset(60, 216)]
		public List<ExternalObject<DataContainer>> Behaviors { get; set; }

		[FieldOffset(64, 224)]
		public List<BWTimelineReference> TimelinesToApplyUponLearning { get; set; }

		[FieldOffset(68, 232)]
		public List<DelayLoadBundleReference> TimelinesToApplyUponLearningRefs { get; set; }

		[FieldOffset(72, 240)]
		public List<ExternalObject<DataContainer>> Upgrades { get; set; }

		[FieldOffset(76, 248)]
		public List<BWAbilityTagRef> Tags { get; set; }

		[FieldOffset(80, 256)]
		public ExternalObject<FloatProvider> AbilityCooldownTimer { get; set; }

		[FieldOffset(84, 264)]
		public ExternalObject<LuaFloatProvider> AutoLevelPriority { get; set; }

		[FieldOffset(88, 272)]
		public bool IsVisibleInCommandList { get; set; }

		[FieldOffset(89, 273)]
		public bool PurchasedAbility { get; set; }

		[FieldOffset(90, 274)]
		public bool AllowFriendlyFire { get; set; }

		public BWAbility()
		{
			AdditionalDescriptors = new List<FloatProviderTokenizedString>();
			DesignerProperties = new List<BWAbilityDesignerProperty>();
			Behaviors = new List<ExternalObject<DataContainer>>();
			TimelinesToApplyUponLearning = new List<BWTimelineReference>();
			TimelinesToApplyUponLearningRefs = new List<DelayLoadBundleReference>();
			Upgrades = new List<ExternalObject<DataContainer>>();
			Tags = new List<BWAbilityTagRef>();
		}
	}
}
