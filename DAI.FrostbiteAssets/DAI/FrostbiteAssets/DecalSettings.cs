namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DecalSettings : SystemSettings
	{
		[FieldOffset(16, 40)]
		public uint DecalImpactLifetimeMs { get; set; }

		[FieldOffset(20, 44)]
		public uint DecalImpactPoolSize { get; set; }

		[FieldOffset(24, 48)]
		public uint StaticBufferMaxVertexCount { get; set; }

		[FieldOffset(28, 52)]
		public uint RingBufferMaxVertexCount { get; set; }

		[FieldOffset(32, 56)]
		public bool Enable { get; set; }

		[FieldOffset(33, 57)]
		public bool DrawEnable { get; set; }

		[FieldOffset(34, 58)]
		public bool SystemEnable { get; set; }

		[FieldOffset(35, 59)]
		public bool SystemEnable2 { get; set; }

		[FieldOffset(36, 60)]
		public bool DrawDecalReflectionOnBreakableModelEnable { get; set; }

		[FieldOffset(37, 61)]
		public bool DebugMemUsageEnable { get; set; }

		[FieldOffset(38, 62)]
		public bool DebugWarningsEnable { get; set; }

		[FieldOffset(39, 63)]
		public bool NvidiaStreamOutputWorkaroundEnable { get; set; }
	}
}
