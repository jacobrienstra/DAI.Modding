using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_PlayExertion : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public int ExertionId { get; set; }

		[FieldOffset(32, 80)]
		public List<ExternalObject<BWCSMAction>> FilterData { get; set; }

		public BWCSMAction_PlayExertion()
		{
			FilterData = new List<ExternalObject<BWCSMAction>>();
		}
	}
}
