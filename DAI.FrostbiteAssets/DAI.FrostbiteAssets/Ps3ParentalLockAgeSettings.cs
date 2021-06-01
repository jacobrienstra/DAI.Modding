namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class Ps3ParentalLockAgeSettings : LinkObject
	{
		[FieldOffset(0, 0)]
		public string Region { get; set; }

		[FieldOffset(4, 8)]
		public Ps3AgeLevels AgeLevels { get; set; }

		[FieldOffset(20, 24)]
		public ExternalObject<Ps3ParentalLockAgeSettingsOverrides> CountryOverrides { get; set; }
	}
}
