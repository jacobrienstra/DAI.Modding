using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIAudioSlider : UIHeadMorphSliderBase
	{
		[FieldOffset(28, 72)]
		public List<byte> VariationIndices { get; set; }

		public UIAudioSlider()
		{
			VariationIndices = new List<byte>();
		}
	}
}
