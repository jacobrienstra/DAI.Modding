namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ChooserTypeWrapper : DataContainer
	{
		[FieldOffset(8, 24)]
		public ExternalObject<ConversationChooserType> ChooserType { get; set; }
	}
}
