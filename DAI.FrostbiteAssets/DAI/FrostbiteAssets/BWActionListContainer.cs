using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWActionListContainer : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<BWCSMAction>> Actions { get; set; }

		public BWActionListContainer()
		{
			Actions = new List<ExternalObject<BWCSMAction>>();
		}
	}
}
