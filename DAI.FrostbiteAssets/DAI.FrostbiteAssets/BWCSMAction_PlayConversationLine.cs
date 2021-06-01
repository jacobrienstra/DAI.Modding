namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_PlayConversationLine : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public string ConversationLine { get; set; }

		[FieldOffset(32, 80)]
		public bool AssertIfLineNotFound { get; set; }
	}
}
