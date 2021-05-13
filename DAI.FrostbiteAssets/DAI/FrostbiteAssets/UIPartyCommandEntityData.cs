using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIPartyCommandEntityData : UICommandEntityData
	{
		[FieldOffset(16, 96)]
		public BWPartyCommandReference PartyCommandReference { get; set; }
	}
}
