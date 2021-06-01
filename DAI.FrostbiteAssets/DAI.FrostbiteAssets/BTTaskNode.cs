namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BTTaskNode : BTNodeData
	{
		[FieldOffset(16, 48)]
		public ExternalObject<BTTaskFunc> Task { get; set; }
	}
}
