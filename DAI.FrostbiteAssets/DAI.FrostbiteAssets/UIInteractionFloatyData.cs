using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIInteractionFloatyData : EntityData
	{
		[FieldOffset(16, 96)]
		public BWInteractionType InteractionType { get; set; }
	}
}
