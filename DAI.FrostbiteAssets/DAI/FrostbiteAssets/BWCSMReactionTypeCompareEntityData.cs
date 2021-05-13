using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMReactionTypeCompareEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 104)]
		public List<int> ReactionNameHashes { get; set; }

		[FieldOffset(24, 112)]
		public int ReactionNameHash { get; set; }

		[FieldOffset(28, 116)]
		public bool InvertResult { get; set; }

		public BWCSMReactionTypeCompareEntityData()
		{
			ReactionNameHashes = new List<int>();
		}
	}
}
