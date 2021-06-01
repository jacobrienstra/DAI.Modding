namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BTScoringNode : BTNodeData
	{
		[FieldOffset(16, 48)]
		public float Score { get; set; }
	}
}
