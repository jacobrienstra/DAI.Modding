using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SelectEventEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 100)]
		public int Selected { get; set; }

		[FieldOffset(24, 104)]
		public List<string> Events { get; set; }

		public SelectEventEntityData()
		{
			Events = new List<string>();
		}
	}
}
