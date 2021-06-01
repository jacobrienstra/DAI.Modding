using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIItemScreenAsset : UILocalizedScreenAsset
	{
		[FieldOffset(68, 192)]
		public List<UIItemMaterialTypeLocalizationData> MaterialLabels { get; set; }

		[FieldOffset(72, 200)]
		public List<UIItemDamageTypeLocalizationData> DamageTypeLabels { get; set; }

		public UIItemScreenAsset()
		{
			MaterialLabels = new List<UIItemMaterialTypeLocalizationData>();
			DamageTypeLabels = new List<UIItemDamageTypeLocalizationData>();
		}
	}
}
