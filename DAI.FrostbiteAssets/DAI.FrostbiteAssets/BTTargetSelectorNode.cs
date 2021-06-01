using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BTTargetSelectorNode : BTNodeDataWithChildren
	{
		[FieldOffset(20, 56)]
		public ExternalObject<EntityListProvider> TargetsToEvaluate { get; set; }

		[FieldOffset(24, 64)]
		public TacticsTarget SpecificTarget { get; set; }

		[FieldOffset(28, 68)]
		public bool IncludeSpecificTarget { get; set; }
	}
}
