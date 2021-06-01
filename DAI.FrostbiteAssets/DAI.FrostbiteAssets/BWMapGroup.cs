using System;
using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWMapGroup : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public Guid MapGroupId { get; set; }

		[FieldOffset(28, 88)]
		public List<BWFloorMap> AreaMaps { get; set; }

		[FieldOffset(32, 96)]
		public List<BWCharacterMapPinState> DynamicPins { get; set; }

		public BWMapGroup()
		{
			AreaMaps = new List<BWFloorMap>();
			DynamicPins = new List<BWCharacterMapPinState>();
		}
	}
}
