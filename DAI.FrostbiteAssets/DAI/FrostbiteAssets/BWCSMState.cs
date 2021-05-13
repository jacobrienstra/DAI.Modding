using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMState : BWCSMStateBase
	{
		[FieldOffset(20, 104)]
		public float Length { get; set; }

		[FieldOffset(24, 112)]
		public List<ExternalObject<BWCSMTimelineEvent>> Branches { get; set; }

		[FieldOffset(28, 120)]
		public bool ResetContext { get; set; }

		[FieldOffset(29, 121)]
		public bool CanSafelyPredictBranches { get; set; }

		public BWCSMState()
		{
			Branches = new List<ExternalObject<BWCSMTimelineEvent>>();
		}
	}
}
