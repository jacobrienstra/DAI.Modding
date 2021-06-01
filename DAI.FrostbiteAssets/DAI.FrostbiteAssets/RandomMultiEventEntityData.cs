using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class RandomMultiEventEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 104)]
		public List<float> RandomEventWeight { get; set; }

		[FieldOffset(24, 112)]
		public List<uint> HashedInputWeights { get; set; }

		[FieldOffset(28, 120)]
		public bool UniformDistribution { get; set; }

		[FieldOffset(29, 121)]
		public bool DisableOutputOnTrigger { get; set; }

		[FieldOffset(30, 122)]
		public bool ResetOutputsWhenAllHasTriggered { get; set; }

		[FieldOffset(31, 123)]
		public bool TrueRandom { get; set; }

		public RandomMultiEventEntityData()
		{
			RandomEventWeight = new List<float>();
			HashedInputWeights = new List<uint>();
		}
	}
}
