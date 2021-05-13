using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DA3PathLink : CustomPathLinkData
	{
		[FieldOffset(8, 24)]
		public DA3PathLinkType PathLinkType { get; set; }
	}
}
