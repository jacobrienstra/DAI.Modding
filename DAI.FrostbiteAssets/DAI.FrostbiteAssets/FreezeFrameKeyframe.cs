namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FreezeFrameKeyframe
	{
		[FieldOffset(0, 0)]
		public float Time { get; set; }

		[FieldOffset(4, 4)]
		public int FramesToFreeze { get; set; }
	}
}
