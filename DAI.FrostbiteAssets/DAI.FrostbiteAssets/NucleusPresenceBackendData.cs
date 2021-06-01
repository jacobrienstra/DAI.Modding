using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class NucleusPresenceBackendData : PresenceBackendData
	{
		[FieldOffset(20, 88)]
		public List<NucleusEnvironmentConfiguration> Environments { get; set; }

		[FieldOffset(24, 96)]
		public List<NucleusPlatformConfiguration> Platforms { get; set; }

		public NucleusPresenceBackendData()
		{
			Environments = new List<NucleusEnvironmentConfiguration>();
			Platforms = new List<NucleusPlatformConfiguration>();
		}
	}
}
