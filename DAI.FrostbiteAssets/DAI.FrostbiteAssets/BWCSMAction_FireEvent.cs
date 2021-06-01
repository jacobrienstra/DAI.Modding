using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_FireEvent : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public List<uint> HashedEventsStart { get; set; }

		[FieldOffset(32, 80)]
		public List<uint> HashedEventsEnd { get; set; }

		[FieldOffset(36, 88)]
		public ExternalObject<Dummy> EventParameterProvider { get; set; }

		public BWCSMAction_FireEvent()
		{
			HashedEventsStart = new List<uint>();
			HashedEventsEnd = new List<uint>();
		}
	}
}
