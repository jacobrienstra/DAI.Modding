using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIHeadMorphSliderPreset : UIHeadMorphSliderBase
	{
		[FieldOffset(28, 72)]
		public UIHeadMorphSliderPresetTypes PresetType { get; set; }
	}
}
