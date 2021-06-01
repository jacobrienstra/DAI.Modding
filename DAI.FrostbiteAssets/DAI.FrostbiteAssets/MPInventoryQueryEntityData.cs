using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MPInventoryQueryEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public List<ExternalObject<BWGameInteractionEntityData>> Filters { get; set; }

		public MPInventoryQueryEntityData()
		{
			Filters = new List<ExternalObject<BWGameInteractionEntityData>>();
		}
	}
}
