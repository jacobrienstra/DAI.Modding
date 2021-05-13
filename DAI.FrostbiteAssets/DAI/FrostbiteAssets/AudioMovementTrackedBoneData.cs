namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AudioMovementTrackedBoneData : DataContainer
	{
		[FieldOffset(8, 24)]
		public int SourceBoneId { get; set; }

		[FieldOffset(12, 32)]
		public string CollisionEvent { get; set; }

		[FieldOffset(16, 40)]
		public string MovementStartEvent { get; set; }

		[FieldOffset(20, 48)]
		public string MovementStopEvent { get; set; }

		[FieldOffset(24, 56)]
		public string MaterialParameter { get; set; }

		[FieldOffset(28, 64)]
		public string PeakHeightParameter { get; set; }

		[FieldOffset(32, 72)]
		public string VelocityParameter { get; set; }

		[FieldOffset(36, 80)]
		public string WaterDepthParameter { get; set; }
	}
}
