using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIGameOptionsScreenAsset : UILocalizedScreenAsset
	{
		[FieldOffset(68, 192)]
		public int DefaultDifficultyID { get; set; }

		[FieldOffset(72, 200)]
		public List<DifficultyNameUIData> DifficultyNames { get; set; }

		[FieldOffset(76, 208)]
		public List<LocalizedStringReference> KinectCommands { get; set; }

		public UIGameOptionsScreenAsset()
		{
			DifficultyNames = new List<DifficultyNameUIData>();
			KinectCommands = new List<LocalizedStringReference>();
		}
	}
}
