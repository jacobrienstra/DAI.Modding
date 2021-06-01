using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class OptionDisabledReasonDescription : LinkObject
	{
		[FieldOffset(0, 0)]
		public OptionDisabledReason optionDisabledReason { get; set; }

		[FieldOffset(4, 8)]
		public LocalizedStringReference DisabledDescription { get; set; }
	}
}
