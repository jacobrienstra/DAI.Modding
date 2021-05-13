using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIHeadMorphSliderBlend : UIHeadMorphSliderBase
	{
		[FieldOffset(28, 72)]
		public List<ExternalObject<LogicPrefabReferenceObjectData>> CustomValueModifiersX { get; set; }

		[FieldOffset(32, 80)]
		public List<ExternalObject<LogicPrefabReferenceObjectData>> CustomValueModifiersY { get; set; }

		public UIHeadMorphSliderBlend()
		{
			CustomValueModifiersX = new List<ExternalObject<LogicPrefabReferenceObjectData>>();
			CustomValueModifiersY = new List<ExternalObject<LogicPrefabReferenceObjectData>>();
		}
	}
}
