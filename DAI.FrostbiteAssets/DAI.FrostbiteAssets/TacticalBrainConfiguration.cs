namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class TacticalBrainConfiguration : SystemSettings
	{
		[FieldOffset(16, 40)]
		public float DistanceToFollowStealthedCharacters { get; set; }
	}
}
