using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWAbilityList : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<BWAbilityList>> ReferencedAbilityLists { get; set; }

		[FieldOffset(16, 80)]
		public List<ExternalObject<DataContainerPolicyAsset>> Abilities { get; set; }

		public BWAbilityList()
		{
			ReferencedAbilityLists = new List<ExternalObject<BWAbilityList>>();
			Abilities = new List<ExternalObject<DataContainerPolicyAsset>>();
		}
	}
}
