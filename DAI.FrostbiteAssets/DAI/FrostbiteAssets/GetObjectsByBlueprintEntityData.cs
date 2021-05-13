using System;
using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class GetObjectsByBlueprintEntityData : BWGetObjectsEntityBaseData
	{
		[FieldOffset(20, 104)]
		public Realm Realm { get; set; }

		[FieldOffset(24, 112)]
		public List<Guid> BlueprintIDs { get; set; }

		public GetObjectsByBlueprintEntityData()
		{
			BlueprintIDs = new List<Guid>();
		}
	}
}
