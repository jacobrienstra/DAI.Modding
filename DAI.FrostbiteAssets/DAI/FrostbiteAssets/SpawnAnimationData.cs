namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SpawnAnimationData : ProcessorData
	{
		[FieldOffset(16, 64)]
		public float AnimationSpeed { get; set; }

		[FieldOffset(20, 68)]
		public bool BasedOnLifetime { get; set; }
	}
}
