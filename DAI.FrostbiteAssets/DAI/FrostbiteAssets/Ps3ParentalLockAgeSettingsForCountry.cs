namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class Ps3ParentalLockAgeSettingsForCountry : LinkObject
	{
		[FieldOffset(0, 0)]
		public string CountryCode { get; set; }

		[FieldOffset(4, 8)]
		public Ps3AgeLevels AgeLevels { get; set; }
	}
}
