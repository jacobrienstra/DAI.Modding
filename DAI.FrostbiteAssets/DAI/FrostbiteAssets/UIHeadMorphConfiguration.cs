using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIHeadMorphConfiguration : DataContainer
	{
		[FieldOffset(8, 24)]
		public int RaceOverrideType { get; set; }

		[FieldOffset(12, 28)]
		public int GenderOverrideType { get; set; }

		[FieldOffset(16, 32)]
		public UIHeadMorphPreset PresetSettings { get; set; }

		[FieldOffset(24, 64)]
		public ExternalObject<UIHeadMorphSliderGroup> RootSlider { get; set; }

		[FieldOffset(28, 72)]
		public List<ExternalObject<LogicPrefabReferenceObjectData>> HeadPresets { get; set; }

		[FieldOffset(32, 80)]
		public LocalizedStringReference FinishedEditingString { get; set; }

		public UIHeadMorphConfiguration()
		{
			HeadPresets = new List<ExternalObject<LogicPrefabReferenceObjectData>>();
		}
	}
}
