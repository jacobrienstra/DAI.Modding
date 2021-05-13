using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIResourceTable : Asset
	{
		[FieldOffset(12, 72)]
		public List<UIResourceTableEntry> Entries { get; set; }

		public UIResourceTable()
		{
			Entries = new List<UIResourceTableEntry>();
		}
	}
}
