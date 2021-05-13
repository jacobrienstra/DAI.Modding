using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class NucleusEnvironmentConfiguration : LinkObject
	{
		[FieldOffset(0, 0)]
		public NucleusEnvironment Env { get; set; }

		[FieldOffset(4, 8)]
		public string BaseUrl { get; set; }

		[FieldOffset(8, 16)]
		public string NucleusClientId { get; set; }
	}
}
