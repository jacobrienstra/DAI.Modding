using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CreatureProfileCollection : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<CreatureProfile>> Profiles { get; set; }

		public CreatureProfileCollection()
		{
			Profiles = new List<ExternalObject<CreatureProfile>>();
		}
	}
}
