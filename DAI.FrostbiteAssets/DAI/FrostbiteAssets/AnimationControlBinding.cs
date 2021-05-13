namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AnimationControlBinding : LinkObject
	{
		[FieldOffset(0, 0)]
		public AntRef AnimationVelocityToPhysics { get; set; }
	}
}
