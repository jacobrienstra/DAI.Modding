using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ItemListEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public List<ExternalObject<LogicReferenceObjectData>> ItemLists { get; set; }

		public ItemListEntityData()
		{
			ItemLists = new List<ExternalObject<LogicReferenceObjectData>>();
		}
	}
}
