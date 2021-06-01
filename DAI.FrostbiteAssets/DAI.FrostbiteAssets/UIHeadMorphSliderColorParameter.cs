using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIHeadMorphSliderColorParameter : UIHeadMorphSliderShaderParameter
	{
		[FieldOffset(32, 96)]
		public List<Vec3> ColorPalette { get; set; }

		[FieldOffset(36, 104)]
		public bool UsePalette { get; set; }

		public UIHeadMorphSliderColorParameter()
		{
			ColorPalette = new List<Vec3>();
		}
	}
}
