namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PlotConditionEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public PlotConditionReference Condition { get; set; }
	}
}
