using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PA2ConversationLookAtTarget : PA2LookAtTarget
	{
		[FieldOffset(12, 32)]
		public ConversationLookAtTargetType TargetType { get; set; }
	}
}
