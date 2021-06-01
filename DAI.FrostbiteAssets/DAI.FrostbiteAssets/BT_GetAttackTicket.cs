using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BT_GetAttackTicket : BTTaskFunc
	{
		[FieldOffset(12, 32)]
		public TacticsTarget Target { get; set; }

		[FieldOffset(16, 36)]
		public float Time { get; set; }

		[FieldOffset(20, 40)]
		public BWTicketTypes TicketType { get; set; }

		[FieldOffset(24, 44)]
		public bool ReleaseTicket { get; set; }
	}
}
