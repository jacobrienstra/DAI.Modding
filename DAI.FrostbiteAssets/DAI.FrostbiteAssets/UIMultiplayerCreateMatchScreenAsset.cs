using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIMultiplayerCreateMatchScreenAsset : UILocalizedScreenAsset
	{
		[FieldOffset(68, 192)]
		public List<MultiplayerDragonStringMapping> DragonMapping { get; set; }

		public UIMultiplayerCreateMatchScreenAsset()
		{
			DragonMapping = new List<MultiplayerDragonStringMapping>();
		}
	}
}
