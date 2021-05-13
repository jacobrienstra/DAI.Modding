using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EventConnection : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<DataContainer> Source { get; set; }

		[FieldOffset(4, 8)]
		public ExternalObject<DataContainer> Target { get; set; }

		[FieldOffset(8, 16)]
		public EventSpec SourceEvent { get; set; }

		[FieldOffset(12, 32)]
		public EventSpec TargetEvent { get; set; }

		[FieldOffset(16, 48)]
		public EventConnectionTargetType TargetType { get; set; }
	}
}
