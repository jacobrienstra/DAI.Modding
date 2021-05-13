using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PresenceBackendData : Asset
	{
		[FieldOffset(12, 72)]
		public List<PresenceRequest> Requests { get; set; }

		[FieldOffset(16, 80)]
		public uint MDMId { get; set; }

		public PresenceBackendData()
		{
			Requests = new List<PresenceRequest>();
		}
	}
}
