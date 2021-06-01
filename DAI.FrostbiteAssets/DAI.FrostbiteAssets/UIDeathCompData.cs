using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIDeathCompData : UIComponentData
	{
		[FieldOffset(32, 136)]
		public List<DeathTipListData> DeathTipLists { get; set; }

		[FieldOffset(36, 144)]
		public List<CustomDeathScreen> CustomDeathScreens { get; set; }

		public UIDeathCompData()
		{
			DeathTipLists = new List<DeathTipListData>();
			CustomDeathScreens = new List<CustomDeathScreen>();
		}
	}
}
