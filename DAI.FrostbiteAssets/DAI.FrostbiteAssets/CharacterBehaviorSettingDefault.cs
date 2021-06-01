using System;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CharacterBehaviorSettingDefault : LinkObject
	{
		[FieldOffset(0, 0)]
		public Guid SettingGuid { get; set; }

		[FieldOffset(16, 16)]
		public uint DefaultChoice { get; set; }
	}
}
