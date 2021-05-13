using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CreatureClassFilterData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 104)]
		public List<CreatureClassFilterEntry> Outputs { get; set; }

		[FieldOffset(24, 112)]
		public List<uint> HashedEvents { get; set; }

		public CreatureClassFilterData()
		{
			Outputs = new List<CreatureClassFilterEntry>();
			HashedEvents = new List<uint>();
		}
	}
}
