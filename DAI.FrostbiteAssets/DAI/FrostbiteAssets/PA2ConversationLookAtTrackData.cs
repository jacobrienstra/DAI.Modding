namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PA2ConversationLookAtTrackData : PA2LookAtTrackData
	{
		[FieldOffset(28, 136)]
		public bool ManagedByConversationEditor { get; set; }
	}
}
