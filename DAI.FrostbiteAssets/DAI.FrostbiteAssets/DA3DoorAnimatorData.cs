namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DA3DoorAnimatorData : EntityData
	{
		[FieldOffset(16, 96)]
		public float OpenCloseTime { get; set; }

		[FieldOffset(20, 100)]
		public float BashTime { get; set; }

		[FieldOffset(24, 104)]
		public bool DoorMirrored { get; set; }

		[FieldOffset(25, 105)]
		public bool DoubleDoorMirrored { get; set; }
	}
}
