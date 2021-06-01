using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BTIteratorNode : BTNodeDataWithChildren
	{
		[FieldOffset(20, 56)]
		public ExternalObject<BTIteratorFunc> Iterator { get; set; }

		[FieldOffset(24, 64)]
		public EIteratorReturnCondition ReturnCondition { get; set; }
	}
}
