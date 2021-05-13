using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ConversationChooserData : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<ConversationChooserType>> ChooserTypes { get; set; }

		[FieldOffset(16, 80)]
		public List<ExternalObject<ConversationChooserType>> SubchooserTypes { get; set; }

		[FieldOffset(20, 88)]
		public List<ExternalObject<ConversationChooserType>> Categories { get; set; }

		[FieldOffset(24, 96)]
		public List<ExternalObject<ConversationChooserType>> CustomIcons { get; set; }

		public ConversationChooserData()
		{
			ChooserTypes = new List<ExternalObject<ConversationChooserType>>();
			SubchooserTypes = new List<ExternalObject<ConversationChooserType>>();
			Categories = new List<ExternalObject<ConversationChooserType>>();
			CustomIcons = new List<ExternalObject<ConversationChooserType>>();
		}
	}
}
