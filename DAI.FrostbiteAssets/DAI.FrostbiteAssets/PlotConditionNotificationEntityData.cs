using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PlotConditionNotificationEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public List<PlotConditionReference> PlotConditions { get; set; }

		[FieldOffset(20, 104)]
		public bool TriggerOnValueChange { get; set; }

		public PlotConditionNotificationEntityData()
		{
			PlotConditions = new List<PlotConditionReference>();
		}
	}
}
