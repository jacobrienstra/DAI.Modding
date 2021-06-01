namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BTIfNode : BTNodeDataWithChildren
	{
		[FieldOffset(20, 56)]
		public ExternalObject<BTEvalFunc> Eval { get; set; }
	}
}
