using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CodexCollectableEntry : CodexEntry
	{
		[FieldOffset(48, 184)]
		public new CodexEntryType EntryType { get; set; }

		[FieldOffset(52, 192)]
		public PlotFlagReference CollectionCounter { get; set; }

		[FieldOffset(68, 232)]
		public List<CollectionTier> Tiers { get; set; }

		public CodexCollectableEntry()
		{
			Tiers = new List<CollectionTier>();
		}
	}
}
