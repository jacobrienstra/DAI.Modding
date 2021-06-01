using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWMultiEventGateEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 104)]
		public List<string> Events { get; set; }

		[FieldOffset(24, 112)]
		public bool Default { get; set; }

		[FieldOffset(25, 113)]
		public bool AutoClose { get; set; }

		public BWMultiEventGateEntityData()
		{
			Events = new List<string>();
		}
	}
}
