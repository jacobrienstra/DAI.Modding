namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class InqExperienceManagerEntityData : ExperienceManagerEntityData
	{
		[FieldOffset(20, 104)]
		public PlotFlagReference InquisitionXP { get; set; }

		[FieldOffset(36, 144)]
		public PlotFlagReference InquisitionRank { get; set; }

		[FieldOffset(52, 184)]
		public PlotFlagReference Agents { get; set; }

		[FieldOffset(68, 224)]
		public PlotFlagReference Perks { get; set; }
	}
}
