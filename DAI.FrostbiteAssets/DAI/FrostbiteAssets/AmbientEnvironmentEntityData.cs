namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AmbientEnvironmentEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public PlotConditionReference Condition { get; set; }

		[FieldOffset(44, 176)]
		public bool Enabled { get; set; }
	}
}
