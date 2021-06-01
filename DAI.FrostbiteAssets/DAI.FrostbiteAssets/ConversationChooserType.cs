using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ConversationChooserType : DataContainer
	{
		[FieldOffset(8, 24)]
		public string ChooserUI { get; set; }

		[FieldOffset(12, 32)]
		public List<ExternalObject<ConversationChooserType>> AutomaticPositions { get; set; }

		[FieldOffset(16, 40)]
		public bool ReturnToSubchooser { get; set; }

		public ConversationChooserType()
		{
			AutomaticPositions = new List<ExternalObject<ConversationChooserType>>();
		}
	}
}
