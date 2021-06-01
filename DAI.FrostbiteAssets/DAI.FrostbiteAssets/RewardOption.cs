using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class RewardOption : DataContainer
	{
		[FieldOffset(8, 24)]
		public float Probability { get; set; }

		[FieldOffset(12, 32)]
		public List<PlotActionReference> RewardActions { get; set; }

		[FieldOffset(16, 40)]
		public ExternalObject<RewardAsset> Rewards { get; set; }

		public RewardOption()
		{
			RewardActions = new List<PlotActionReference>();
		}
	}
}
