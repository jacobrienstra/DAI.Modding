using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MixerPresetGroupData : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<MixGroup> Group { get; set; }

		[FieldOffset(4, 8)]
		public MixGroupState State { get; set; }

		[FieldOffset(8, 12)]
		public float AttackTime { get; set; }

		[FieldOffset(12, 16)]
		public float ReleaseTime { get; set; }

		[FieldOffset(16, 20)]
		public int Priority { get; set; }

		[FieldOffset(20, 24)]
		public List<MixGroupPropertyValue> Properties { get; set; }

		[FieldOffset(24, 32)]
		public bool IsDominant { get; set; }

		[FieldOffset(25, 33)]
		public bool IsAdditive { get; set; }

		public MixerPresetGroupData()
		{
			Properties = new List<MixGroupPropertyValue>();
		}
	}
}
