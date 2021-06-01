using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class Ps4AgeSettings : LinkObject
	{
		[FieldOffset(0, 0)]
		public int DefaultAgeRequirement { get; set; }

		[FieldOffset(4, 8)]
		public List<Ps4RegionAgeDefault> RegionAgeDefaults { get; set; }

		[FieldOffset(8, 16)]
		public List<Ps4CountryAgeOverrides> AgeOverrides { get; set; }

		public Ps4AgeSettings()
		{
			RegionAgeDefaults = new List<Ps4RegionAgeDefault>();
			AgeOverrides = new List<Ps4CountryAgeOverrides>();
		}
	}
}
