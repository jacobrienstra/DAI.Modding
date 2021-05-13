namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MusicPlayableData : DataContainer
	{
		[FieldOffset(8, 24)]
		public string Name { get; set; }

		[FieldOffset(12, 32)]
		public uint PlayCount { get; set; }

		[FieldOffset(16, 36)]
		public float MinDelay { get; set; }

		[FieldOffset(20, 40)]
		public float MaxDelay { get; set; }

		[FieldOffset(24, 44)]
		public uint BeatsPerMinute { get; set; }

		[FieldOffset(28, 48)]
		public uint BeatsPerBar { get; set; }

		[FieldOffset(32, 52)]
		public float Gain { get; set; }

		[FieldOffset(36, 56)]
		public float Pitch { get; set; }
	}
}
