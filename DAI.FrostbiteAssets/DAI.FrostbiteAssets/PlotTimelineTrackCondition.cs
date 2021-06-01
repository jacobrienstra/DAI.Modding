using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PlotTimelineTrackCondition : TimelineTrackDataConditionsBase
	{
		[FieldOffset(8, 32)]
		public List<PlotConditionReference> Conditions { get; set; }

		public PlotTimelineTrackCondition()
		{
			Conditions = new List<PlotConditionReference>();
		}
	}
}
