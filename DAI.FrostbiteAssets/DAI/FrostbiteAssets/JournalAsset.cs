using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class JournalAsset : TreeBase
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<JournalEntry>> ChildNodes { get; set; }

		public JournalAsset()
		{
			ChildNodes = new List<ExternalObject<JournalEntry>>();
		}
	}
}
