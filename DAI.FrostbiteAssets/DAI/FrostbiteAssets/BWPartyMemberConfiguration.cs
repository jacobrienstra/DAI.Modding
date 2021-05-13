using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWPartyMemberConfiguration : Asset
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<BWPartyMemberData>> AllPartyMembers { get; set; }

		[FieldOffset(16, 80)]
		public List<ExternalObject<BWPartyMemberData>> AllMultiplayerCharacters { get; set; }

		public BWPartyMemberConfiguration()
		{
			AllPartyMembers = new List<ExternalObject<BWPartyMemberData>>();
			AllMultiplayerCharacters = new List<ExternalObject<BWPartyMemberData>>();
		}
	}
}
