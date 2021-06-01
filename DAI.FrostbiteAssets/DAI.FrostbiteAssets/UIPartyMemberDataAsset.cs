using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIPartyMemberDataAsset : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public List<PartyMemberUIData> PartyMembers { get; set; }

		public UIPartyMemberDataAsset()
		{
			PartyMembers = new List<PartyMemberUIData>();
		}
	}
}
