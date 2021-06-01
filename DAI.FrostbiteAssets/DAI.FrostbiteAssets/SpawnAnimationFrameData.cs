namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SpawnAnimationFrameData : ProcessorData
	{
		[FieldOffset(16, 64)]
		public uint AnimationFrame { get; set; }
	}
}
