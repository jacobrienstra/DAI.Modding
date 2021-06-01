using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_RotateToFace : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public List<RotateToFace_Transform> Reference { get; set; }

		[FieldOffset(32, 80)]
		public RotateToFace_Mode UpdateMode { get; set; }

		[FieldOffset(36, 84)]
		public float MaxRate { get; set; }

		public BWCSMAction_RotateToFace()
		{
			Reference = new List<RotateToFace_Transform>();
		}
	}
}
