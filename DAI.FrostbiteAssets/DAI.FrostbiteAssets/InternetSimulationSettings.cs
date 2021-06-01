namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class InternetSimulationSettings
	{
		[FieldOffset(0, 0)]
		public float ReorderRatioMin { get; set; }

		[FieldOffset(4, 4)]
		public float ReorderRatioMax { get; set; }

		[FieldOffset(8, 8)]
		public float LatencyMin { get; set; }

		[FieldOffset(12, 12)]
		public float LatencyMax { get; set; }

		[FieldOffset(16, 16)]
		public float LatencyVariance { get; set; }

		[FieldOffset(20, 20)]
		public float DuplicateRatioMin { get; set; }

		[FieldOffset(24, 24)]
		public float DuplicateRatioMax { get; set; }

		[FieldOffset(28, 28)]
		public float DropRatioMin { get; set; }

		[FieldOffset(32, 32)]
		public float DropRatioMax { get; set; }

		[FieldOffset(36, 36)]
		public float CorruptRatioMin { get; set; }

		[FieldOffset(40, 40)]
		public float CorruptRatioMax { get; set; }

		[FieldOffset(44, 44)]
		public float SizeRatioMin { get; set; }

		[FieldOffset(48, 48)]
		public float SizeRatioMax { get; set; }

		[FieldOffset(52, 52)]
		public float SpikeDurationMin { get; set; }

		[FieldOffset(56, 56)]
		public float SpikeDurationMax { get; set; }

		[FieldOffset(60, 60)]
		public float SpikeDurationVariance { get; set; }

		[FieldOffset(64, 64)]
		public float SpikeCooldownMin { get; set; }

		[FieldOffset(68, 68)]
		public float SpikeCooldownMax { get; set; }

		[FieldOffset(72, 72)]
		public float SpikeCooldownVariance { get; set; }

		[FieldOffset(76, 76)]
		public bool Enable { get; set; }
	}
}
