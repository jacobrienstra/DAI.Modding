namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class RumbleEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public float Duration { get; set; }

		[FieldOffset(20, 100)]
		public float Low { get; set; }

		[FieldOffset(24, 104)]
		public float High { get; set; }

		[FieldOffset(28, 108)]
		public float MaxRange { get; set; }

		[FieldOffset(32, 112)]
		public float MinRange { get; set; }
	}
}
