using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class OnlineProviderAsset : Asset
	{
		[FieldOffset(12, 72)]
		public List<OnlineProviderConfiguration> Configurations { get; set; }

		public OnlineProviderAsset()
		{
			Configurations = new List<OnlineProviderConfiguration>();
		}
	}
}
