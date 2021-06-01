namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class DebrisClusterPartInfoData
	{
		[FieldOffset(0, 0)]
		public Vec3 LinearVelocity { get; set; }

		[FieldOffset(16, 16)]
		public Vec3 AngularVelocity { get; set; }

		[FieldOffset(32, 32)]
		public int PartIndex { get; set; }

		[FieldOffset(36, 36)]
		public int NumberOfChildren { get; set; }

		[FieldOffset(40, 40)]
		public float SplitSpeedThreshold { get; set; }

		[FieldOffset(44, 44)]
		public float DespawnTimeVariance { get; set; }

		[FieldOffset(48, 48)]
		public bool SyncRestPosition { get; set; }

		[FieldOffset(49, 49)]
		public bool SyncContinous { get; set; }

		[FieldOffset(50, 50)]
		public bool InEffectWorldOnly { get; set; }
	}
}
