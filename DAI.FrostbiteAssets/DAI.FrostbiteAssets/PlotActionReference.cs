using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PlotActionReference : LinkObject
	{
		[FieldOffset(0, 0)]
		public PlotActionType ActionType { get; set; }

		[FieldOffset(4, 8)]
		public ExternalObject<ActionLogicPrefabBlueprint> ActionSchematic { get; set; }

		[FieldOffset(8, 16)]
		public PlotFlagReference PlotFlagReference { get; set; }
	}
}
