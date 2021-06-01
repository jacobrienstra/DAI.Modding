using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_FireEventOnTarget : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public Realm Realm { get; set; }

		[FieldOffset(32, 80)]
		public ExternalObject<EntityProvider_Partner> Entity { get; set; }

		[FieldOffset(36, 88)]
		public List<uint> HashedEventsStart { get; set; }

		[FieldOffset(40, 96)]
		public List<uint> HashedEventsEnd { get; set; }

		public BWCSMAction_FireEventOnTarget()
		{
			HashedEventsStart = new List<uint>();
			HashedEventsEnd = new List<uint>();
		}
	}
}
