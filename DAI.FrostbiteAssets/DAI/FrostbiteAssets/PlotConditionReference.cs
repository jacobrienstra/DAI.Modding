using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PlotConditionReference : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<ConditionLogicPrefabBlueprint> ConditionSchematic { get; set; }

		[FieldOffset(4, 8)]
		public PlotConditionType ConditionType { get; set; }

		[FieldOffset(8, 16)]
		public PlotFlagReference PlotFlagReference { get; set; }

		[FieldOffset(24, 56)]
		public bool DesiredValue { get; set; }
	}
}
