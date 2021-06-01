using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWCSMComponentData : GameComponentData
	{
		[FieldOffset(96, 176)]
		public ExternalObject<CSMStateReference> InitialStateRef { get; set; }

		[FieldOffset(100, 184)]
		public ExternalObject<BWCSMSyncReactionSet> SyncReactions { get; set; }

		[FieldOffset(104, 192)]
		public AntRef SpeedModifier { get; set; }

		[FieldOffset(124, 240)]
		public List<EventSpec> AnimatableTypeNameAndEventId { get; set; }

		[FieldOffset(128, 248)]
		public ExternalObject<CSMStateAliasMap> AliasMap { get; set; }

		[FieldOffset(132, 256)]
		public bool AIBranchingEnabled { get; set; }

		[FieldOffset(133, 257)]
		public bool AutoEnable { get; set; }

		public BWCSMComponentData()
		{
			AnimatableTypeNameAndEventId = new List<EventSpec>();
		}
	}
}
