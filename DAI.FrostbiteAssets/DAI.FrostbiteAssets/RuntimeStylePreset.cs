using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class RuntimeStylePreset
	{
		[FieldOffset(0, 0)]
		public int Value { get; set; }

		[FieldOffset(4, 4)]
		public UIHeadMorphSliderPresetTypes PresetType { get; set; }
	}
}
