namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BTWrapperNode : BTNodeDataWithChildren
	{
		[FieldOffset(20, 56)]
		public bool ReturnTrue { get; set; }
	}
}
