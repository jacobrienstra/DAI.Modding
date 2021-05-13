using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIInputEventNodePort : UINodePort
	{
		[FieldOffset(24, 48)]
		public UIInputAction InputEventType { get; set; }
	}
}
