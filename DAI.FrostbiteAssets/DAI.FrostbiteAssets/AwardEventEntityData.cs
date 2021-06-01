using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AwardEventEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public AwardEvent EventToTrigger { get; set; }
	}
}
