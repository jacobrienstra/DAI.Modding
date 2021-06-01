namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWLocomotionAnimationComponentData : GameComponentData
	{
		[FieldOffset(96, 176)]
		public BWLocomotionAnimationComponentBinding AnimationBinding { get; set; }

		[FieldOffset(176, 368)]
		public float StoppingThreshold { get; set; }
	}
}
