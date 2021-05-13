namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class TacticsCommandMoveToPositionData : TacticsCommandData
	{
		[FieldOffset(16, 96)]
		public ExternalObject<TransformProvider_Select> GoalTransform { get; set; }

		[FieldOffset(20, 104)]
		public float CommandFinishedRadius { get; set; }
	}
}
