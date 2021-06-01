using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIAnalogInputMapData : LinkObject
	{
		[FieldOffset(0, 0)]
		public UIAnalogInput AnalogInput { get; set; }

		[FieldOffset(4, 4)]
		public InputConceptIdentifiers XAxisConceptIdentifier { get; set; }

		[FieldOffset(8, 8)]
		public InputConceptIdentifiers YAxisConceptIdentifier { get; set; }

		[FieldOffset(12, 12)]
		public float OverrideDeadZone { get; set; }
	}
}
