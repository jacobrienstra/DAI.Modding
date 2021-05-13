using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class TacticsCommandListenerEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public int PartyMemberID { get; set; }

		[FieldOffset(20, 104)]
		public List<TacticsCommandType> CommandEvents { get; set; }

		[FieldOffset(24, 112)]
		public bool UsePlayerCharacter { get; set; }

		[FieldOffset(25, 113)]
		public bool IgnoreAiIssuedCommands { get; set; }

		public TacticsCommandListenerEntityData()
		{
			CommandEvents = new List<TacticsCommandType>();
		}
	}
}
