using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class TraversalProperties : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public List<MantleCSMStateEntry> MantleUpCSMStateList { get; set; }

		[FieldOffset(16, 80)]
		public List<StepUpCSMStateEntry> StepUpCSMStateList { get; set; }

		[FieldOffset(20, 88)]
		public List<VaultCSMStateEntry> VaultCSMStateList { get; set; }

		[FieldOffset(24, 96)]
		public List<DropDownCSMStateEntry> DropDownCSMStateList { get; set; }

		public TraversalProperties()
		{
			MantleUpCSMStateList = new List<MantleCSMStateEntry>();
			StepUpCSMStateList = new List<StepUpCSMStateEntry>();
			VaultCSMStateList = new List<VaultCSMStateEntry>();
			DropDownCSMStateList = new List<DropDownCSMStateEntry>();
		}
	}
}
