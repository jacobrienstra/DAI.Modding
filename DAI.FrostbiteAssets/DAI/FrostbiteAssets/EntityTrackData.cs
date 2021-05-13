using System;
using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EntityTrackData : EntityTrackBaseData
	{
		[FieldOffset(36, 144)]
		public List<Guid> GuidChain { get; set; }

		public EntityTrackData()
		{
			GuidChain = new List<Guid>();
		}
	}
}
