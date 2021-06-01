using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMReactionSet : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public List<BWCSMReactionPairing> Reactions { get; set; }

		public BWCSMReactionSet()
		{
			Reactions = new List<BWCSMReactionPairing>();
		}
	}
}
