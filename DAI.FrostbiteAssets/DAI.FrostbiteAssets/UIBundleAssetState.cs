using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIBundleAssetState : LinkObject
	{
		[FieldOffset(0, 0)]
		public string StateName { get; set; }

		[FieldOffset(4, 8)]
		public UIState UIState { get; set; }

		[FieldOffset(8, 16)]
		public string StatePath { get; set; }

		[FieldOffset(12, 24)]
		public string BundlePath { get; set; }
	}
}
