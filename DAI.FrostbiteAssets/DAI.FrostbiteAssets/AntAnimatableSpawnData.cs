namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AntAnimatableSpawnData : DataContainer
	{
		[FieldOffset(8, 24)]
		public AntAnimationHandlerData AnimationData { get; set; }
	}
}
