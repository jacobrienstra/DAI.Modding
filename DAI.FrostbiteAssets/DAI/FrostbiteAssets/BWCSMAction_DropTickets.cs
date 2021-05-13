using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_DropTickets : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public List<BWTicketTypes> TicketTypes { get; set; }

		[FieldOffset(32, 80)]
		public bool DropAllTickets { get; set; }

		public BWCSMAction_DropTickets()
		{
			TicketTypes = new List<BWTicketTypes>();
		}
	}
}
