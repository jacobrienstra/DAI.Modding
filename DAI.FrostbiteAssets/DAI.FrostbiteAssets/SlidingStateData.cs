namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SlidingStateData : CharacterStateData
	{
		[FieldOffset(12, 32)]
		public float HorizontalInputScale { get; set; }

		[FieldOffset(16, 36)]
		public float GravityScale { get; set; }

		[FieldOffset(20, 40)]
		public float SlideSpeed { get; set; }
	}
}
