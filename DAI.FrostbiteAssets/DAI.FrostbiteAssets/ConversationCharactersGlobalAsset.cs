using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ConversationCharactersGlobalAsset : Asset
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<PartyMemberData>> Party { get; set; }

		public ConversationCharactersGlobalAsset()
		{
			Party = new List<ExternalObject<PartyMemberData>>();
		}
	}
}
