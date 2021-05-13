using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_PlayFilteredConversationLine : BWCSMAction_PlayConversationLine
	{
		[FieldOffset(36, 88)]
		public List<ExternalObject<BWCSMAction>> FilterData { get; set; }

		public BWCSMAction_PlayFilteredConversationLine()
		{
			FilterData = new List<ExternalObject<BWCSMAction>>();
		}
	}
}
