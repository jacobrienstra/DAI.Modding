using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWGetObjectsByGroupEntityData : BWGetObjectsEntityBaseData
	{
		[FieldOffset(20, 104)]
		public List<Dummy> Groups { get; set; }

		[FieldOffset(24, 112)]
		public GroupObjectType GroupType { get; set; }

		public BWGetObjectsByGroupEntityData()
		{
			Groups = new List<Dummy>();
		}
	}
}
