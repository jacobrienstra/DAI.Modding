namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PlotActionEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public PlotActionReference Action { get; set; }
	}
}
