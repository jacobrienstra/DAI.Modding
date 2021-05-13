using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIQuickbarCompData : UIComponentData
	{
		[FieldOffset(32, 136)]
		public List<UIHeroMenuListData> LockedElements { get; set; }

		public UIQuickbarCompData()
		{
			LockedElements = new List<UIHeroMenuListData>();
		}
	}
}
