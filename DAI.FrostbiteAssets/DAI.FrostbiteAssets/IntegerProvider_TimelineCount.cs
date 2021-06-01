using System;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class IntegerProvider_TimelineCount : IntegerProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<EntityProvider> Entity { get; set; }

		[FieldOffset(12, 40)]
		public Guid TimelineGuid { get; set; }
	}
}
