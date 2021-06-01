using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIGameOptionsItemAsset : UITreeFlowAsset
	{
		[FieldOffset(64, 216)]
		public LocalizedStringReference DisabledDescription { get; set; }

		[FieldOffset(68, 240)]
		public UITreeFlowChildType ChildListType { get; set; }

		[FieldOffset(72, 244)]
		public ProfileOptionsType OptionCategory { get; set; }

		[FieldOffset(76, 248)]
		public UIGameOptionsDataType OptionDataType { get; set; }

		[FieldOffset(80, 256)]
		public ExternalObject<ProfileOptionData> OptionData { get; set; }

		[FieldOffset(84, 264)]
		public PlotFlagReference PlotFlag { get; set; }

		[FieldOffset(100, 304)]
		public UIGameOptionsRoundingPrecision OptionDataPrecision { get; set; }

		[FieldOffset(104, 308)]
		public UIGameOptionsDisplayType OptionDisplayType { get; set; }

		[FieldOffset(108, 312)]
		public List<LocalizedStringReference> EnumDisplayStrings { get; set; }

		[FieldOffset(112, 320)]
		public int DLCPackage { get; set; }

		[FieldOffset(116, 324)]
		public bool ApplyChangesImmediately { get; set; }

		[FieldOffset(117, 325)]
		public bool VisibleInDemoMode { get; set; }

		[FieldOffset(118, 326)]
		public bool IsRestartRequired { get; set; }

		[FieldOffset(119, 327)]
		public bool AdvancedGraphicsQualityOption { get; set; }

		[FieldOffset(120, 328)]
		public bool HideInMenu { get; set; }

		[FieldOffset(121, 329)]
		public bool HideInMultiplayer { get; set; }

		[FieldOffset(122, 330)]
		public bool CycleEnumValues { get; set; }

		public UIGameOptionsItemAsset()
		{
			EnumDisplayStrings = new List<LocalizedStringReference>();
		}
	}
}
