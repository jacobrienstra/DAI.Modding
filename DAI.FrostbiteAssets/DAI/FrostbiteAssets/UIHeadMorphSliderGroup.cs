using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIHeadMorphSliderGroup : UIHeadMorphSliderBase
	{
		[FieldOffset(28, 72)]
		public LocalizedStringReference Gen3AltTitle { get; set; }

		[FieldOffset(32, 96)]
		public List<ExternalObject<LogicPrefabReferenceObjectData>> SubSliders { get; set; }

		public UIHeadMorphSliderGroup()
		{
			SubSliders = new List<ExternalObject<LogicPrefabReferenceObjectData>>();
		}
	}
}
