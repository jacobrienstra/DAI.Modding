using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class JournalEntryBase : TreeNodeBase
	{
		[FieldOffset(8, 32)]
		public List<PlotConditionReference> DisplayConditions { get; set; }

		[FieldOffset(12, 40)]
		public List<PlotConditionReference> HideConditions { get; set; }

		[FieldOffset(16, 48)]
		public ExternalObject<JournalSystemCategory> Category { get; set; }

		[FieldOffset(20, 56)]
		public LocalizedStringReference TitleReference { get; set; }

		[FieldOffset(24, 80)]
		public List<uint> TextEntryHashes { get; set; }

		[FieldOffset(28, 88)]
		public string TexturePath { get; set; }

		public JournalEntryBase()
		{
			DisplayConditions = new List<PlotConditionReference>();
			HideConditions = new List<PlotConditionReference>();
			TextEntryHashes = new List<uint>();
		}
	}
}
