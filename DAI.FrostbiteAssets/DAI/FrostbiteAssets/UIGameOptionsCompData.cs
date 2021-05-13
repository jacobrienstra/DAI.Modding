using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIGameOptionsCompData : UIComponentData
	{
		[FieldOffset(32, 136)]
		public List<OptionDisabledReasonDescription> SpecialDisabledDescriptions { get; set; }

		[FieldOffset(36, 144)]
		public LocalizedStringReference KinectDialectSelectionWarning { get; set; }

		[FieldOffset(40, 168)]
		public int CustomDifficultyId { get; set; }

		[FieldOffset(44, 172)]
		public int CustomDifficultyDLCPackage { get; set; }

		public UIGameOptionsCompData()
		{
			SpecialDisabledDescriptions = new List<OptionDisabledReasonDescription>();
		}
	}
}
