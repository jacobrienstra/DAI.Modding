using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIHeadMorphSliderShape : UIHeadMorphSliderBase
	{
		[FieldOffset(28, 72)]
		public LocalizedStringReference BlendTitle { get; set; }

		[FieldOffset(32, 96)]
		public List<uint> SliderIds { get; set; }

		public UIHeadMorphSliderShape()
		{
			SliderIds = new List<uint>();
		}
	}
}
