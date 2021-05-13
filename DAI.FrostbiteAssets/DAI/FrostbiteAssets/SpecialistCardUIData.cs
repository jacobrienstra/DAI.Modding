namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SpecialistCardUIData : LinkObject
	{
		[FieldOffset(0, 0)]
		public LocalizedStringReference SpecialistName { get; set; }

		[FieldOffset(4, 24)]
		public string CardPortraitName { get; set; }

		[FieldOffset(8, 32)]
		public LocalizedStringReference SpecialistTypeName { get; set; }

		[FieldOffset(12, 56)]
		public string CardPortraitSpecialistTypeName { get; set; }
	}
}
