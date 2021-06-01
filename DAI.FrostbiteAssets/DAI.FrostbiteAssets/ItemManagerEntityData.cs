using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class ItemManagerEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Vec3 UpCompareColor { get; set; }

		[FieldOffset(32, 112)]
		public Vec3 DownCompareColor { get; set; }

		[FieldOffset(48, 128)]
		public Vec3 RequirementPassedColor { get; set; }

		[FieldOffset(64, 144)]
		public Vec3 RequirementFailedColor { get; set; }

		[FieldOffset(80, 160)]
		public Vec3 OptionalFailedColor { get; set; }

		[FieldOffset(96, 176)]
		public ExternalObject<BWIntegralStat> PlayerClassStat { get; set; }

		[FieldOffset(100, 184)]
		public ExternalObject<BWIntegralStat> ItemRaceStat { get; set; }

		[FieldOffset(104, 192)]
		public ExternalObject<BWModifiableStat> ItemDamageStat { get; set; }

		[FieldOffset(108, 200)]
		public ExternalObject<BWModifiableStat> RuneDamageStat { get; set; }

		[FieldOffset(112, 208)]
		public ExternalObject<BWModifiableStat> HeadDamageStat { get; set; }

		[FieldOffset(116, 216)]
		public ExternalObject<BWModifiableStat> AttackStat { get; set; }

		[FieldOffset(120, 224)]
		public ExternalObject<BWModifiableStat> ItemArmorStat { get; set; }

		[FieldOffset(124, 232)]
		public ExternalObject<BWModifiableStat> ItemArmorFrontStat { get; set; }

		[FieldOffset(128, 240)]
		public ExternalObject<BWModifiableStat> ConstitutionStat { get; set; }

		[FieldOffset(132, 248)]
		public ExternalObject<BWModifiableStat> ItemDefenseMeleeStat { get; set; }

		[FieldOffset(136, 256)]
		public ExternalObject<BWModifiableStat> ItemDefenseRangedStat { get; set; }

		[FieldOffset(140, 264)]
		public ExternalObject<BWModifiableStat> ItemDefenseMagicStat { get; set; }

		[FieldOffset(144, 272)]
		public Delegate_float DpsDelegate { get; set; }

		[FieldOffset(156, 296)]
		public ExternalObject<UIPartyMemberDataAsset> PartyMemberData { get; set; }

		[FieldOffset(160, 304)]
		public List<RecipeMaterialTypeCopyInfo> MaterialTypeCopyInfo { get; set; }

		[FieldOffset(164, 312)]
		public List<ItemManagerEntity_PotionData> PotionsData { get; set; }

		[FieldOffset(168, 320)]
		public List<ItemManagerEntity_PotionUpgradeData> PotionUpgradesData { get; set; }

		[FieldOffset(172, 328)]
		public LocalizedStringReference StatText { get; set; }

		[FieldOffset(176, 352)]
		public LocalizedStringReference ColoredStatText { get; set; }

		[FieldOffset(180, 376)]
		public LocalizedStringReference EmptyUpgradeText { get; set; }

		[FieldOffset(184, 400)]
		public LocalizedStringReference RequirementText { get; set; }

		[FieldOffset(188, 424)]
		public LocalizedStringReference RestrictionText { get; set; }

		[FieldOffset(192, 448)]
		public LocalizedStringReference DoubleRestrictionText { get; set; }

		[FieldOffset(196, 472)]
		public LocalizedStringReference NegFollowerRestrictionText { get; set; }

		[FieldOffset(200, 496)]
		public LocalizedStringReference NegRaceRestrictionText { get; set; }

		[FieldOffset(204, 520)]
		public LocalizedStringReference EquippedByText { get; set; }

		[FieldOffset(208, 544)]
		public LocalizedStringReference ItemLevelText { get; set; }

		[FieldOffset(212, 568)]
		public LocalizedStringReference ItemTypeText { get; set; }

		[FieldOffset(216, 592)]
		public LocalizedStringReference InvCapacityText { get; set; }

		[FieldOffset(220, 616)]
		public LocalizedStringReference InvCapacityTextColored { get; set; }

		[FieldOffset(224, 640)]
		public LocalizedStringReference RecipeSlotRequirementText { get; set; }

		[FieldOffset(228, 664)]
		public LocalizedStringReference RecipeDescriptionText { get; set; }

		[FieldOffset(232, 688)]
		public LocalizedStringReference MasterworkRecipeSlotName { get; set; }

		[FieldOffset(236, 712)]
		public LocalizedStringReference MasterworkMaterialName { get; set; }

		[FieldOffset(240, 736)]
		public LocalizedStringReference NotMeltableText { get; set; }

		[FieldOffset(244, 760)]
		public LocalizedStringReference InventoryFullText { get; set; }

		[FieldOffset(248, 784)]
		public LocalizedStringReference StaffRuneRestrictionText { get; set; }

		[FieldOffset(252, 808)]
		public LocalizedStringReference NonStaffRuneRestrictionText { get; set; }

		[FieldOffset(256, 832)]
		public List<ItemManagerEntity_ClassInfo> ClassInfos { get; set; }

		[FieldOffset(260, 840)]
		public List<ItemManagerEntity_RaceInfo> RaceInfos { get; set; }

		[FieldOffset(264, 848)]
		public List<ItemManagerEntity_DamageTypeInfo> DamageTypeInfos { get; set; }

		[FieldOffset(268, 856)]
		public List<ItemManagerEntity_ItemQualityInfo> ItemQualityInfos { get; set; }

		[FieldOffset(272, 864)]
		public List<ItemManagerEntity_EquipSlotInfo> EquipSlotInfos { get; set; }

		[FieldOffset(276, 872)]
		public List<ItemManagerEntity_MaterialInfo> MaterialInfos { get; set; }

		[FieldOffset(280, 880)]
		public List<ItemManagerEntity_ArchetypeInfo> ArchetypeInfos { get; set; }

		[FieldOffset(284, 888)]
		public List<ItemManagerEntity_WeaponStyleInfo> WeaponStyleInfos { get; set; }

		[FieldOffset(288, 896)]
		public LocalizedStringReference AOEDamageStatString { get; set; }

		[FieldOffset(292, 920)]
		public LocalizedStringReference DpsStatName { get; set; }

		[FieldOffset(296, 944)]
		public ExternalObject<ItemBlueprint> QuiverAppearance { get; set; }

		[FieldOffset(300, 952)]
		public ExternalObject<BlendedSocketInfo> QuiverSocketInfo { get; set; }

		[FieldOffset(304, 960)]
		public ExternalObject<EquipItemType> BiancaType { get; set; }

		[FieldOffset(308, 968)]
		public List<ExternalObject<LogicReferenceObjectData>> PlaceholderArmors { get; set; }

		[FieldOffset(312, 976)]
		public int SigilDLCPackage { get; set; }

		public ItemManagerEntityData()
		{
			MaterialTypeCopyInfo = new List<RecipeMaterialTypeCopyInfo>();
			PotionsData = new List<ItemManagerEntity_PotionData>();
			PotionUpgradesData = new List<ItemManagerEntity_PotionUpgradeData>();
			ClassInfos = new List<ItemManagerEntity_ClassInfo>();
			RaceInfos = new List<ItemManagerEntity_RaceInfo>();
			DamageTypeInfos = new List<ItemManagerEntity_DamageTypeInfo>();
			ItemQualityInfos = new List<ItemManagerEntity_ItemQualityInfo>();
			EquipSlotInfos = new List<ItemManagerEntity_EquipSlotInfo>();
			MaterialInfos = new List<ItemManagerEntity_MaterialInfo>();
			ArchetypeInfos = new List<ItemManagerEntity_ArchetypeInfo>();
			WeaponStyleInfos = new List<ItemManagerEntity_WeaponStyleInfo>();
			PlaceholderArmors = new List<ExternalObject<LogicReferenceObjectData>>();
		}
	}
}
