using System;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BoolProvider_HasTimeline : BWConditional
	{
		[FieldOffset(8, 32)]
		public Guid TimelineGuid { get; set; }

		[FieldOffset(24, 48)]
		public ExternalObject<EntityProvider> Entity { get; set; }
	}
}
