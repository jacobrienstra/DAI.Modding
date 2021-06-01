namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PlotCondition : DataContainer
	{
		[FieldOffset(8, 24)]
		public ExternalObject<ConditionLogicPrefabBlueprint> ConditionSchematic { get; set; }
	}
}
