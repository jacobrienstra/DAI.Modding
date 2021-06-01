using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIEventAsset : Asset
	{
		[FieldOffset(12, 72)]
		public string Category { get; set; }

		[FieldOffset(16, 80)]
		public List<string> EventList { get; set; }

		public UIEventAsset()
		{
			EventList = new List<string>();
		}
	}
}
