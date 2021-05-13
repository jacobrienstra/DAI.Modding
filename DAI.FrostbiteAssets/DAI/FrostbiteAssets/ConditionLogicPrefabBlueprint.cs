using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ConditionLogicPrefabBlueprint : AbstractPlotLogicPrefabBlueprint
	{
		[FieldOffset(40, 200)]
		public List<PlotFlagId> PlotFlagIds { get; set; }

		public ConditionLogicPrefabBlueprint()
		{
			PlotFlagIds = new List<PlotFlagId>();
		}
	}
}
