using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ConditionGroup : AudioGraphNodePortGroup
	{
		[FieldOffset(8, 24)]
		public AudioGraphNodePort X { get; set; }

		[FieldOffset(16, 56)]
		public AudioGraphNodePort Y { get; set; }

		[FieldOffset(24, 88)]
		public AudioGraphNodePort True { get; set; }

		[FieldOffset(32, 120)]
		public ConditionType Condition { get; set; }
	}
}
