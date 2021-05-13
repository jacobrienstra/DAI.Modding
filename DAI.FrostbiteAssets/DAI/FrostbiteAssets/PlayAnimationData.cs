namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PlayAnimationData : DataContainer
	{
		[FieldOffset(8, 24)]
		public AntRef Controller { get; set; }

		[FieldOffset(28, 72)]
		public bool Looping { get; set; }
	}
}
