namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWAnimationControlledComponentData : GameComponentData
	{
		[FieldOffset(96, 176)]
		public BWAnimationControlledComponentBinding AnimationBinding { get; set; }

		[FieldOffset(396, 896)]
		public float MaxTerrainTraversalAngle { get; set; }
	}
}
