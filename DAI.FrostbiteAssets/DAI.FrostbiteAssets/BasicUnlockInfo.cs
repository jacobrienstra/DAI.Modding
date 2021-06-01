using System;
using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BasicUnlockInfo : LinkObject
	{
		[FieldOffset(0, 0)]
		public Guid UnlockGuid { get; set; }

		[FieldOffset(16, 16)]
		public uint Identifier { get; set; }

		[FieldOffset(20, 20)]
		public uint UnlockScore { get; set; }

		[FieldOffset(24, 24)]
		public List<Dummy> Licenses { get; set; }

		[FieldOffset(28, 32)]
		public List<Dummy> AdditionalLicenses { get; set; }

		[FieldOffset(32, 40)]
		public string StringId { get; set; }

		public BasicUnlockInfo()
		{
			Licenses = new List<Dummy>();
			AdditionalLicenses = new List<Dummy>();
		}
	}
}
