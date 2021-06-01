using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWNearbyTagTriggerEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public LinearTransform TrackingOffset { get; set; }

		[FieldOffset(80, 160)]
		public Realm Realm { get; set; }

		[FieldOffset(84, 164)]
		public int TrackingPoint { get; set; }

		[FieldOffset(88, 168)]
		public List<string> Tags { get; set; }

		[FieldOffset(92, 176)]
		public float InRangeRadius { get; set; }

		[FieldOffset(96, 180)]
		public float OutOfRangeRadius { get; set; }

		[FieldOffset(100, 184)]
		public int MaxInRangeTags { get; set; }

		public BWNearbyTagTriggerEntityData()
		{
			Tags = new List<string>();
		}
	}
}
