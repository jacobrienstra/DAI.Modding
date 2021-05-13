using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CSMStateAliasMap : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public List<CSMStateRemapping> Mapping { get; set; }

		public CSMStateAliasMap()
		{
			Mapping = new List<CSMStateRemapping>();
		}
	}
}
