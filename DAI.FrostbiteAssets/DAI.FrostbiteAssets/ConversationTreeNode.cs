using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ConversationTreeNode : TreeNodeBase
	{
		[FieldOffset(8, 32)]
		public List<ExternalObject<ConversationLine>> ChildNodes { get; set; }

		[FieldOffset(12, 40)]
		public ExternalObject<ConversationChooserType> ChooserType { get; set; }

		[FieldOffset(16, 48)]
		public ExternalObject<ConversationCategory> Category { get; set; }

		[FieldOffset(20, 56)]
		public ExternalObject<ConversationCustomIcon> IconOverride { get; set; }

		[FieldOffset(24, 64)]
		public float Timeout { get; set; }

		[FieldOffset(28, 72)]
		public LocalizedStringReference ParaphraseReference { get; set; }

		[FieldOffset(32, 96)]
		public LocalizedStringReference HoverTextReference { get; set; }

		public ConversationTreeNode()
		{
			ChildNodes = new List<ExternalObject<ConversationLine>>();
		}
	}
}
