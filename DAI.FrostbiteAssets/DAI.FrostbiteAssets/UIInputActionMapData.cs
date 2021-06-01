using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIInputActionMapData : LinkObject
	{
		[FieldOffset(0, 0)]
		public UIInputAction InputAction { get; set; }

		[FieldOffset(4, 4)]
		public InputConceptIdentifiers ConceptIdentifier { get; set; }

		[FieldOffset(8, 8)]
		public float OverrideRepeatDelaySec { get; set; }

		[FieldOffset(12, 12)]
		public float OverrideRepeatSpeedSec { get; set; }

		[FieldOffset(16, 16)]
		public bool AllowRepeat { get; set; }
	}
}
