namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ConversationStringReference : LinkObject
	{
		[FieldOffset(0, 0)]
		public LocalizedStringReference String { get; set; }

		[FieldOffset(4, 24)]
		public ExternalObject<LocalizedCharacter> Speaker { get; set; }

		[FieldOffset(8, 32)]
		public bool IsTempLine { get; set; }
	}
}
