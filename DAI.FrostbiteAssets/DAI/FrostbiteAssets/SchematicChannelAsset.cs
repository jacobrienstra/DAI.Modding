using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SchematicChannelAsset : Asset
	{
		[FieldOffset(12, 72)]
		public List<EventChannel> Events { get; set; }

		[FieldOffset(16, 80)]
		public List<LinkChannel> Links { get; set; }

		[FieldOffset(20, 88)]
		public List<PropertyChannel> Properties { get; set; }

		public SchematicChannelAsset()
		{
			Events = new List<EventChannel>();
			Links = new List<LinkChannel>();
			Properties = new List<PropertyChannel>();
		}
	}
}
