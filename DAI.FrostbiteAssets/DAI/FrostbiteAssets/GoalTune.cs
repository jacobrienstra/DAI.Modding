namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class GoalTune : Asset
	{
		[FieldOffset(12, 72)]
		public float preferredTurningRadius { get; set; }

		[FieldOffset(16, 76)]
		public bool useCircularApproach { get; set; }
	}
}
