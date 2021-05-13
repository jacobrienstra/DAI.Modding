namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ConversationLink : ConversationTreeNode
	{
		[FieldOffset(36, 136)]
		public ExternalObject<ConversationLine> LinkedLine { get; set; }

		[FieldOffset(40, 144)]
		public bool Override { get; set; }
	}
}
