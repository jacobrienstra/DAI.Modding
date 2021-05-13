using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class WidgetEventQueryPair : LinkObject
	{
		[FieldOffset(0, 0)]
		public string Name { get; set; }

		[FieldOffset(4, 8)]
		public UIWidgetEventID Query { get; set; }

		[FieldOffset(8, 16)]
		public string InstanceName { get; set; }

		[FieldOffset(12, 24)]
		public bool IsOutput { get; set; }
	}
}
