using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EquipItemAsset : StatItemAsset
	{
		[FieldOffset(124, 320)]
		public ExternalObject<ItemAppearance> EquipItemAppearance { get; set; }

		[FieldOffset(128, 328)]
		public ExternalObject<EquipItemType> CastedItemType { get; set; }

		[FieldOffset(132, 336)]
		public ExternalObject<UpgradeSet> UpgradeSet { get; set; }

		[FieldOffset(136, 344)]
		public List<ExternalObject<DataContainer>> InitialUpgrades { get; set; }

		[FieldOffset(140, 352)]
		public RandomizedUpgradeAttachment RandomizedUpgradeAttachment { get; set; }

		[FieldOffset(152, 376)]
		public Vec2 VFXTransform { get; set; }

		[FieldOffset(160, 384)]
		public int RequirementFollower { get; set; }

		[FieldOffset(164, 392)]
		public List<PartyMemberClassType> RequirementClasses { get; set; }

		[FieldOffset(168, 400)]
		public int RequirementRace { get; set; }

		[FieldOffset(172, 408)]
		public List<BWItemStatValuePair> RequirementStats { get; set; }

		[FieldOffset(176, 416)]
		public List<BWItemStatValuePair> RequirementStatsSP { get; set; }

		[FieldOffset(180, 424)]
		public ExternalObject<WarPaintAppearanceAsset> WarPaintAppearanceAsset { get; set; }

		[FieldOffset(184, 432)]
		public AlternateHeadMorphChoice AlternateHeadMorph { get; set; }

		[FieldOffset(188, 440)]
		public ExternalObject<Dummy> ItemModificationOverride { get; set; }

		[FieldOffset(192, 448)]
		public bool NegateFollowerRequirement { get; set; }

		[FieldOffset(193, 449)]
		public bool NegateRaceRequirement { get; set; }

		[FieldOffset(194, 450)]
		public bool TurnOffHairWhenEquippedAsHelmet { get; set; }

		[FieldOffset(195, 451)]
		public bool TurnOffBeardWhenEquippedAsHelmet { get; set; }

		[FieldOffset(196, 452)]
		public bool TurnOffFaceWhenEquippedAsHelmet { get; set; }

		[FieldOffset(197, 453)]
		public bool DestroyOnEquip { get; set; }

		[FieldOffset(198, 454)]
		public bool TurnOffQuiverWhenEquippedAsArmor { get; set; }

		[FieldOffset(199, 455)]
		public bool HideHelmetWhenEquippedAsArmor { get; set; }

		public EquipItemAsset()
		{
			InitialUpgrades = new List<ExternalObject<DataContainer>>();
			RequirementClasses = new List<PartyMemberClassType>();
			RequirementStats = new List<BWItemStatValuePair>();
			RequirementStatsSP = new List<BWItemStatValuePair>();
		}
	}
}
