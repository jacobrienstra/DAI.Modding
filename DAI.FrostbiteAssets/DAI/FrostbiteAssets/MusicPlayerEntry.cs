namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MusicPlayerEntry : AudioGraphNodePortGroup
	{
		[FieldOffset(8, 24)]
		public AudioGraphNodePort In { get; set; }

		[FieldOffset(16, 56)]
		public uint TargetNameHash { get; set; }

		[FieldOffset(20, 60)]
		public bool IsEvent { get; set; }
	}
}
