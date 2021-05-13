using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class NucleusPlatformConfiguration : LinkObject
	{
		[FieldOffset(0, 0)]
		public GamePlatform Platform { get; set; }

		[FieldOffset(4, 8)]
		public string ClientId { get; set; }

		[FieldOffset(8, 16)]
		public string ClientSecret { get; set; }

		[FieldOffset(12, 24)]
		public string LoginScope { get; set; }

		[FieldOffset(16, 32)]
		public string ClientRedirectUrl { get; set; }

		[FieldOffset(20, 40)]
		public string BlazeServerClientId { get; set; }

		[FieldOffset(24, 48)]
		public string DisplayType { get; set; }
	}
}
