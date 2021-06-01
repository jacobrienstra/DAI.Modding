using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWAbilityAliasMap : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public List<BWAbilityAliasMapEntry> Entries { get; set; }

		public BWAbilityAliasMap()
		{
			Entries = new List<BWAbilityAliasMapEntry>();
		}
	}
}
