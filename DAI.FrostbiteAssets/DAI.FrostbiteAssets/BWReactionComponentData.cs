using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWReactionComponentData : GameComponentData
	{
		[FieldOffset(96, 176)]
		public ExternalObject<BWCSMReactionSet> DefaultReactions { get; set; }

		[FieldOffset(100, 184)]
		public List<OverrideReactionPair> OverrideReactionList { get; set; }

		public BWReactionComponentData()
		{
			OverrideReactionList = new List<OverrideReactionPair>();
		}
	}
}
