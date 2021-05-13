using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EnumToLocalizedStringMapperEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public List<InputConceptAndLocalizedStringPair> MappedInputConcepts { get; set; }

		[FieldOffset(20, 104)]
		public List<InputActionMouseAndLocalizedStringPair> MappedInputActionsMouse { get; set; }

		[FieldOffset(24, 112)]
		public List<InputActionPadAndLocalizedStringPair> MappedInputActionsPad { get; set; }

		public EnumToLocalizedStringMapperEntityData()
		{
			MappedInputConcepts = new List<InputConceptAndLocalizedStringPair>();
			MappedInputActionsMouse = new List<InputActionMouseAndLocalizedStringPair>();
			MappedInputActionsPad = new List<InputActionPadAndLocalizedStringPair>();
		}
	}
}
