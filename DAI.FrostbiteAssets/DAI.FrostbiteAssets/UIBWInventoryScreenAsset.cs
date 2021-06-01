using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIBWInventoryScreenAsset : UIItemScreenAsset
	{
		[FieldOffset(76, 208)]
		public LocalizedStringReference RootBreadCrumb { get; set; }

		[FieldOffset(80, 232)]
		public ExternalObject<UIBWInventoryCategories> Categories { get; set; }

		[FieldOffset(84, 240)]
		public float NewIndicatorTimeout { get; set; }

		[FieldOffset(88, 244)]
		public float MarkToSellDelayTimeout { get; set; }

		[FieldOffset(92, 248)]
		public LocalizedStringReference DestroyButtonString { get; set; }

		[FieldOffset(96, 272)]
		public LocalizedStringReference CancelButtonString { get; set; }

		[FieldOffset(100, 296)]
		public List<UIBWInventorySimpleChooserEquipType> SimpleChooserEquipTypes { get; set; }

		[FieldOffset(104, 304)]
		public List<InputConceptIdentifiers> CameraHUDPassthroughInputs { get; set; }

		public UIBWInventoryScreenAsset()
		{
			SimpleChooserEquipTypes = new List<UIBWInventorySimpleChooserEquipType>();
			CameraHUDPassthroughInputs = new List<InputConceptIdentifiers>();
		}
	}
}
