using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PathfindingSystemEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public List<uint> PathfindingTypesOnLevel { get; set; }

		[FieldOffset(20, 104)]
		public Realm Realm { get; set; }

		public PathfindingSystemEntityData()
		{
			PathfindingTypesOnLevel = new List<uint>();
		}
	}
}
