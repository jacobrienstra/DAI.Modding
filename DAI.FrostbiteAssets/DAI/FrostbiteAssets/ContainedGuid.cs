using System;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ContainedGuid
	{
		[FieldOffset(0, 0)]
		public Guid Guid { get; set; }
	}
}
