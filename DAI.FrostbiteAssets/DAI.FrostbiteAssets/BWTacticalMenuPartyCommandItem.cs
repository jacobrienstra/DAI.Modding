using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWTacticalMenuPartyCommandItem : BWTacticalMenuBaseItem
	{
		[FieldOffset(24, 64)]
		public BWPartyCommandReference CommandReference { get; set; }
	}
}
