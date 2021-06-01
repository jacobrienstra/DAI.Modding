using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class RecipeMaterial : BaseMaterial
	{
		[FieldOffset(112, 328)]
		public RecipeMaterialTypes MaterialType { get; set; }

		[FieldOffset(116, 332)]
		public int StarValue { get; set; }

		[FieldOffset(120, 336)]
		public int StaffDamageType { get; set; }

		[FieldOffset(124, 344)]
		public List<CraftingMaterialCategoryStats> PrimarySlotData { get; set; }

		[FieldOffset(128, 352)]
		public List<CraftingMaterialCategoryStats> BaseSlotData { get; set; }

		[FieldOffset(132, 360)]
		public List<CraftingMaterialStats> UtilitySlotData { get; set; }

		[FieldOffset(136, 368)]
		public bool SuppressClassRestriction { get; set; }

		public RecipeMaterial()
		{
			PrimarySlotData = new List<CraftingMaterialCategoryStats>();
			BaseSlotData = new List<CraftingMaterialCategoryStats>();
			UtilitySlotData = new List<CraftingMaterialStats>();
		}
	}
}
