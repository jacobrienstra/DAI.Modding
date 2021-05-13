using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UICharGenCustomDifficultyCompData : UIComponentData
	{
		[FieldOffset(32, 136)]
		public List<CustomDifficultyOptionsAndCards> OptionsAndCards { get; set; }

		[FieldOffset(36, 144)]
		public int CustomDifficultyID { get; set; }

		[FieldOffset(40, 152)]
		public ExternalObject<UIDifficultySelectionDataAsset> DifficultySelectionAsset { get; set; }

		[FieldOffset(44, 160)]
		public LocalizedStringReference TrialsLabelTemplateString { get; set; }

		[FieldOffset(48, 184)]
		public LocalizedStringReference TrialsLabelString { get; set; }

		public UICharGenCustomDifficultyCompData()
		{
			OptionsAndCards = new List<CustomDifficultyOptionsAndCards>();
		}
	}
}
