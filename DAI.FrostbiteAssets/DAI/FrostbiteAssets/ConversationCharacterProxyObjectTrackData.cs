using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ConversationCharacterProxyObjectTrackData : PartyMemberProxyObjectTrackData
	{
		[FieldOffset(36, 160)]
		public AnyPartyProxyInteractionPolicy AnyPartyProxyInteractionPolicy { get; set; }

		[FieldOffset(40, 164)]
		public int CharacterLinkId { get; set; }

		[FieldOffset(44, 168)]
		public ExternalObject<ConversationCharactersGlobalAsset> ConversationCharactersGlobalAsset { get; set; }

		[FieldOffset(48, 176)]
		public ExternalObject<PartyMemberData> PartyMember { get; set; }

		[FieldOffset(52, 184)]
		public bool IsPlayer { get; set; }
	}
}
