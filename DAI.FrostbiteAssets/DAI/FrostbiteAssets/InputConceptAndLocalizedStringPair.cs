using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class InputConceptAndLocalizedStringPair : LinkObject
	{
		[FieldOffset(0, 0)]
		public InputConceptIdentifiers InputConcept { get; set; }

		[FieldOffset(4, 8)]
		public LocalizedStringReference InputConceptString { get; set; }

		[FieldOffset(8, 32)]
		public LocalizedStringReference NegatedInputConceptString { get; set; }
	}
}
