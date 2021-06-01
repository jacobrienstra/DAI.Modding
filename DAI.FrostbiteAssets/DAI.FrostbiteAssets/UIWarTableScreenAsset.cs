using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIWarTableScreenAsset : UILocalizedScreenAsset
	{
		[FieldOffset(68, 192)]
		public PlotFlagReference Agents { get; set; }

		[FieldOffset(84, 232)]
		public PlotFlagReference Perks { get; set; }

		[FieldOffset(100, 272)]
		public PlotFlagReference FirstOperationCompleted { get; set; }

		[FieldOffset(116, 312)]
		public List<SpecialistCardUIData> Specialists { get; set; }

		[FieldOffset(120, 320)]
		public MapBinaryChoiceInfo LeftMapInfo { get; set; }

		[FieldOffset(136, 392)]
		public MapBinaryChoiceInfo RightMapInfo { get; set; }

		public UIWarTableScreenAsset()
		{
			Specialists = new List<SpecialistCardUIData>();
		}
	}
}
