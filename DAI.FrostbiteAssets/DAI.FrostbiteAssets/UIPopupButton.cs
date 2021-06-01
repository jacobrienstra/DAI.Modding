using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIPopupButton : LinkObject
	{
		[FieldOffset(0, 0)]
		public UIInputAction InputConcept { get; set; }

		[FieldOffset(4, 8)]
		public string Label { get; set; }
	}
}
