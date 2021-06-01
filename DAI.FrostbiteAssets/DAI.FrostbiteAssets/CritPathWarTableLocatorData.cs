using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class CritPathWarTableLocatorData : SpecializingInteractableLocatorData
	{
		[FieldOffset(80, 176)]
		public int Cost { get; set; }

		[FieldOffset(84, 180)]
		public WarTableEntryType SpecialistAssigned { get; set; }

		[FieldOffset(88, 184)]
		public LocalizedStringReference CritPathName { get; set; }

		[FieldOffset(92, 208)]
		public LocalizedStringReference CritPathDescription { get; set; }

		[FieldOffset(96, 232)]
		public string CritPathImageName { get; set; }

		[FieldOffset(100, 240)]
		public string InstallGroup { get; set; }

		[FieldOffset(104, 248)]
		public bool IsAvailableInTrial { get; set; }
	}
}
