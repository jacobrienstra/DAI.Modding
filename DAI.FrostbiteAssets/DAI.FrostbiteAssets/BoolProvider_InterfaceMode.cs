using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BoolProvider_InterfaceMode : BoolProvider
	{
		[FieldOffset(8, 32)]
		public InterfaceModes InterfaceMode { get; set; }
	}
}
