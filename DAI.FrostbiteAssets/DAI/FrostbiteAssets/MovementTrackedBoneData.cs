namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MovementTrackedBoneData : DataContainer
	{
		[FieldOffset(8, 24)]
		public int SourceBoneId { get; set; }

		[FieldOffset(12, 28)]
		public float CollisionThreshold { get; set; }

		[FieldOffset(16, 32)]
		public float ConversationCollisionThreshold { get; set; }

		[FieldOffset(20, 36)]
		public float VelocityThreshold { get; set; }

		[FieldOffset(24, 40)]
		public float ConversationVelocityThreshold { get; set; }

		[FieldOffset(28, 44)]
		public uint TrendDequeSize { get; set; }

		[FieldOffset(32, 48)]
		public bool CheckForCollisions { get; set; }

		[FieldOffset(33, 49)]
		public bool UseTrendDeque { get; set; }

		[FieldOffset(34, 50)]
		public bool CheckDistanceToBoundingBox { get; set; }

		[FieldOffset(35, 51)]
		public bool CanCollideWithSelf { get; set; }

		[FieldOffset(36, 52)]
		public bool CheckWaterDepth { get; set; }

		[FieldOffset(37, 53)]
		public bool OnlyCheckBoundingBoxInConversation { get; set; }

		[FieldOffset(38, 54)]
		public bool CheckVelocity { get; set; }
	}
}
