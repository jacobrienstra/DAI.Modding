using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class PlotSubLevelStreamingTriggerEntityData : SubLevelStreamingTriggerEntityData
	{
		[FieldOffset(144, 272)]
		public PlotStreamingStateUpdatePolicy StateUpdatePolicy { get; set; }

		[FieldOffset(148, 280)]
		public List<SubLevelStreamingTriggerState> RuntimeStates { get; set; }

		public PlotSubLevelStreamingTriggerEntityData()
		{
			RuntimeStates = new List<SubLevelStreamingTriggerState>();
		}
	}
}
