using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EntryInputActionMappingData : InputActionMappingData
	{
		[FieldOffset(8, 24)]
		public int ActionIdentifier { get; set; }

		[FieldOffset(12, 28)]
		public InputConceptIdentifiers ConceptIdentifier { get; set; }
	}
}
