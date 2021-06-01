namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ProceduralAnimationTypeSimple : DataContainer
	{
		[FieldOffset(8, 24)]
		public float BendMultiplier { get; set; }

		[FieldOffset(12, 28)]
		public float WiggleSpeedMultiplier { get; set; }

		[FieldOffset(16, 32)]
		public float WindInfluenceMultiplier { get; set; }
	}
}
