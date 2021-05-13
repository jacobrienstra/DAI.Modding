namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ConversationCustomIcon : DataContainer
	{
		[FieldOffset(8, 24)]
		public string IconPath { get; set; }
	}
}
