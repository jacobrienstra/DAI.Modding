using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MPServerMapping : BWGameplaySettings
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<MPServerMappingUpgradeSet>> UpgradeSetMap { get; set; }

		[FieldOffset(16, 80)]
		public List<ExternalObject<MPServerMappingUpgradeSet>> UpgradeItemSlotMap { get; set; }

		[FieldOffset(20, 88)]
		public List<ExternalObject<MPServerMappingUpgradeSet>> CraftingSlotMap { get; set; }

		[FieldOffset(24, 96)]
		public List<ExternalObject<Dummy>> CraftingSlotNameMap { get; set; }

		[FieldOffset(28, 104)]
		public List<ExternalObject<MPServerMappingUpgradeSet>> EquipSlotMap { get; set; }

		[FieldOffset(32, 112)]
		public List<ExternalObject<MPServerMappingUpgradeSet>> StatMap { get; set; }

		[FieldOffset(36, 120)]
		public List<ExternalObject<MPServerMappingUpgradeSet>> AbilityMap { get; set; }

		[FieldOffset(40, 128)]
		public List<ExternalObject<MPServerMappingUpgradeSet>> InputMap { get; set; }

		[FieldOffset(44, 136)]
		public List<ExternalObject<MPServerMappingUpgradeSet>> NumericSlotMap { get; set; }

		[FieldOffset(48, 144)]
		public List<ExternalObject<MPServerMappingUpgradeSet>> ItemTypeMap { get; set; }

		[FieldOffset(52, 152)]
		public List<ExternalObject<MPServerMappingUpgradeSet>> ChallengePortraits { get; set; }

		[FieldOffset(56, 160)]
		public List<ExternalObject<MPServerMappingUpgradeSet>> ChallengeBanners { get; set; }

		[FieldOffset(60, 168)]
		public List<ExternalObject<MPServerMappingUpgradeSet>> ChallengeTitles { get; set; }

		public MPServerMapping()
		{
			UpgradeSetMap = new List<ExternalObject<MPServerMappingUpgradeSet>>();
			UpgradeItemSlotMap = new List<ExternalObject<MPServerMappingUpgradeSet>>();
			CraftingSlotMap = new List<ExternalObject<MPServerMappingUpgradeSet>>();
			CraftingSlotNameMap = new List<ExternalObject<Dummy>>();
			EquipSlotMap = new List<ExternalObject<MPServerMappingUpgradeSet>>();
			StatMap = new List<ExternalObject<MPServerMappingUpgradeSet>>();
			AbilityMap = new List<ExternalObject<MPServerMappingUpgradeSet>>();
			InputMap = new List<ExternalObject<MPServerMappingUpgradeSet>>();
			NumericSlotMap = new List<ExternalObject<MPServerMappingUpgradeSet>>();
			ItemTypeMap = new List<ExternalObject<MPServerMappingUpgradeSet>>();
			ChallengePortraits = new List<ExternalObject<MPServerMappingUpgradeSet>>();
			ChallengeBanners = new List<ExternalObject<MPServerMappingUpgradeSet>>();
			ChallengeTitles = new List<ExternalObject<MPServerMappingUpgradeSet>>();
		}
	}
}
