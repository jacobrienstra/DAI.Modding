using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIHeadMorphSliderStyle : UIHeadMorphSliderBase
	{
		[FieldOffset(28, 72)]
		public List<RuntimeStyleChooser> RuntimeStyleChooser { get; set; }

		[FieldOffset(32, 80)]
		public List<ExternalObject<Dummy>> DisabledSliders { get; set; }

		public UIHeadMorphSliderStyle()
		{
			RuntimeStyleChooser = new List<RuntimeStyleChooser>();
			DisabledSliders = new List<ExternalObject<Dummy>>();
		}
	}
}
