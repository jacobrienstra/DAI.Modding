using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BosPresenceBackendData : PresenceBackendData
	{
		[FieldOffset(20, 88)]
		public List<UrlConfig> UrlConfigList { get; set; }

		[FieldOffset(24, 96)]
		public string Title { get; set; }

		[FieldOffset(28, 104)]
		public float RequestRetryTimeout { get; set; }

		[FieldOffset(32, 108)]
		public uint RequestRetryCount { get; set; }

		public BosPresenceBackendData()
		{
			UrlConfigList = new List<UrlConfig>();
		}
	}
}
