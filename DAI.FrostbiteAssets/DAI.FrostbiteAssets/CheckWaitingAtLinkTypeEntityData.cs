using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CheckWaitingAtLinkTypeEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public DA3PathLinkType PathLinkType { get; set; }
	}
}
