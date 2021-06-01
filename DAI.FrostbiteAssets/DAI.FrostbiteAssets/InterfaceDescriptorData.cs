using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class InterfaceDescriptorData : DynamicDataContainer
	{
		[FieldOffset(12, 32)]
		public List<DynamicEvent> InputEvents { get; set; }

		[FieldOffset(16, 40)]
		public List<DynamicEvent> OutputEvents { get; set; }

		[FieldOffset(20, 48)]
		public List<DynamicLink> InputLinks { get; set; }

		[FieldOffset(24, 56)]
		public List<DynamicLink> OutputLinks { get; set; }

		public InterfaceDescriptorData()
		{
			InputEvents = new List<DynamicEvent>();
			OutputEvents = new List<DynamicEvent>();
			InputLinks = new List<DynamicLink>();
			OutputLinks = new List<DynamicLink>();
		}
	}
}
