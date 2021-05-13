using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIDifficultySelectionDataAsset : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public int DefaultDifficultyID { get; set; }

		[FieldOffset(16, 80)]
		public List<DifficultyModeUIData> DifficultyModes { get; set; }

		public UIDifficultySelectionDataAsset()
		{
			DifficultyModes = new List<DifficultyModeUIData>();
		}
	}
}
