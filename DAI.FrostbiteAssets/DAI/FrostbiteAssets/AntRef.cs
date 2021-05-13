using System;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AntRef : LinkObject
	{
		[FieldOffset(0, 0)]
		public Guid AssetGuid { get; set; }

		[FieldOffset(16, 16)]
		public int ProjectId { get; set; }
	}
}
