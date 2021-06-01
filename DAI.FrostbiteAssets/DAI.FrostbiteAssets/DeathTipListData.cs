using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DeathTipListData : LinkObject
	{
		[FieldOffset(0, 0)]
		public string DeathTipListName { get; set; }

		[FieldOffset(4, 8)]
		public List<LocalizedStringReference> DeathTips { get; set; }

		public DeathTipListData()
		{
			DeathTips = new List<LocalizedStringReference>();
		}
	}
}
