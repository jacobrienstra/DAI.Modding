using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class OnlineServicesAsset : Asset
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<PresenceFriendsServiceData>> OnlineServices { get; set; }

		public OnlineServicesAsset()
		{
			OnlineServices = new List<ExternalObject<PresenceFriendsServiceData>>();
		}
	}
}
