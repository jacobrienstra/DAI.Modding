using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWInputRestrictionEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public BWInputDeactivationAction Action { get; set; }

		[FieldOffset(20, 104)]
		public List<int> Inputs { get; set; }

		[FieldOffset(24, 112)]
		public bool DisableUIInputs { get; set; }

		public BWInputRestrictionEntityData()
		{
			Inputs = new List<int>();
		}
	}
}
