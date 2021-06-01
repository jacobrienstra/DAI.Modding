using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ConversationSubchooserType : ConversationChooserType
	{
		[FieldOffset(20, 48)]
		public LocalizedStringReference SubChooserCaption { get; set; }

		[FieldOffset(24, 72)]
		public LocalizedStringReference BackCaption { get; set; }

		[FieldOffset(28, 96)]
		public ConversationChooserPosition SubChooserPosition { get; set; }

		[FieldOffset(32, 100)]
		public ConversationChooserPosition BackPosition { get; set; }
	}
}
