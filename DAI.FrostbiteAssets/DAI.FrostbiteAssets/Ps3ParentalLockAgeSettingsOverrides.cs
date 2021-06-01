using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class Ps3ParentalLockAgeSettingsOverrides : DataContainer
	{
		[FieldOffset(8, 24)]
		public List<Ps3ParentalLockAgeSettingsForCountry> Overrides { get; set; }

		public Ps3ParentalLockAgeSettingsOverrides()
		{
			Overrides = new List<Ps3ParentalLockAgeSettingsForCountry>();
		}
	}
}
