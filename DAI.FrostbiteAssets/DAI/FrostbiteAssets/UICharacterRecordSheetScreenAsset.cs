using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UICharacterRecordSheetScreenAsset : UILocalizedScreenAsset
	{
		[FieldOffset(68, 192)]
		public PlotFlagReference Agents { get; set; }

		[FieldOffset(84, 232)]
		public PlotFlagReference Perks { get; set; }

		[FieldOffset(100, 272)]
		public PlotFlagReference JoinedInquisition { get; set; }

		[FieldOffset(116, 312)]
		public List<StatsWithCategory> StatLists { get; set; }

		public UICharacterRecordSheetScreenAsset()
		{
			StatLists = new List<StatsWithCategory>();
		}
	}
}
