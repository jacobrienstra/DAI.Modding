namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIExternalLocStringIDToLocalizedString : LinkObject
	{
		[FieldOffset(0, 0)]
		public string Key { get; set; }

		[FieldOffset(4, 8)]
		public LocalizedStringReference DisplayString { get; set; }
	}
}
