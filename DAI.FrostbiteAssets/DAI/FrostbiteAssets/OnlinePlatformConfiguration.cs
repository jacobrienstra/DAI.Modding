using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class OnlinePlatformConfiguration : LinkObject
	{
		[FieldOffset(0, 0)]
		public GamePlatform Platform { get; set; }

		[FieldOffset(4, 8)]
		public ExternalObject<OnlineServicesAsset> Services { get; set; }

		[FieldOffset(8, 16)]
		public List<ExternalObject<GameSettings>> ClientBackends { get; set; }

		[FieldOffset(12, 24)]
		public List<ExternalObject<GameSettings>> ServerBackends { get; set; }

		[FieldOffset(16, 32)]
		public bool IsFallback { get; set; }

		public OnlinePlatformConfiguration()
		{
			ClientBackends = new List<ExternalObject<GameSettings>>();
			ServerBackends = new List<ExternalObject<GameSettings>>();
		}
	}
}
