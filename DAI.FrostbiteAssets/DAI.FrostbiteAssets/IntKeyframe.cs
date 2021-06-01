namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class IntKeyframe
	{
		[FieldOffset(0, 0)]
		public float Time { get; set; }

		[FieldOffset(4, 4)]
		public int Value { get; set; }
	}
}
