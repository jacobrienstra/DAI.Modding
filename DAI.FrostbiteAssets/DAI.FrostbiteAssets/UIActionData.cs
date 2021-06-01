using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIActionData : Asset
	{
		[FieldOffset(12, 72)]
		public List<string> ActionKeys { get; set; }

		public UIActionData()
		{
			ActionKeys = new List<string>();
		}
	}
}
