using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIBaseChoiceAsset : Asset
	{
		[FieldOffset(12, 72)]
		public LocalizedStringReference ChoicePageTitle { get; set; }

		[FieldOffset(16, 96)]
		public List<LocalizedStringReference> Breadcrumbs { get; set; }

		[FieldOffset(20, 104)]
		public UIBaseChoiceOption LeftChoice { get; set; }

		[FieldOffset(40, 192)]
		public UIBaseChoiceOption RightChoice { get; set; }

		public UIBaseChoiceAsset()
		{
			Breadcrumbs = new List<LocalizedStringReference>();
		}
	}
}
