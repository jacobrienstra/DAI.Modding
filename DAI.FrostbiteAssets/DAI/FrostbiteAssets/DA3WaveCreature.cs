namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DA3WaveCreature : LinkObject
	{
		[FieldOffset(0, 0)]
		public uint CreatureBundleHash { get; set; }

		[FieldOffset(4, 4)]
		public int Count { get; set; }

		[FieldOffset(8, 8)]
		public int Value { get; set; }

		[FieldOffset(12, 16)]
		public ExternalObject<CreatureProfile> CreatureProfile { get; set; }
	}
}
