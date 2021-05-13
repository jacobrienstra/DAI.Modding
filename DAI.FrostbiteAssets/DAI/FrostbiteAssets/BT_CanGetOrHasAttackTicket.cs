using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BT_CanGetOrHasAttackTicket : BTEvalFunc
	{
		[FieldOffset(16, 40)]
		public BWTicketTypes TicketType { get; set; }

		[FieldOffset(20, 44)]
		public TacticsTarget Target { get; set; }
	}
}
