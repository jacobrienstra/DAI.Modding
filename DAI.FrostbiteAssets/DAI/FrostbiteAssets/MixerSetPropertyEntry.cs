namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MixerSetPropertyEntry : AudioGraphNodePortGroup
	{
		[FieldOffset(8, 24)]
		public AudioGraphNodePort In { get; set; }

		[FieldOffset(16, 56)]
		public uint Target { get; set; }

		[FieldOffset(20, 64)]
		public ExternalObject<MixGroup> Group { get; set; }

		[FieldOffset(24, 72)]
		public float AttackTime { get; set; }

		[FieldOffset(28, 76)]
		public float ReleaseTime { get; set; }
	}
}
