using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ConversationTypesGlobalAsset : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<ConversationTypeSettings>> Types { get; set; }

		[FieldOffset(16, 80)]
		public List<int> AllCustomFlagIds { get; set; }

		public ConversationTypesGlobalAsset()
		{
			Types = new List<ExternalObject<ConversationTypeSettings>>();
			AllCustomFlagIds = new List<int>();
		}
	}
}
