namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ConversationMasterLinkEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public uint ConversationEntityId { get; set; }
	}
}
