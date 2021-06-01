namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DofTrackKeyframe : DataContainer
	{
		[FieldOffset(8, 24)]
		public float Time { get; set; }

		[FieldOffset(12, 32)]
		public DofParameters DofParameters { get; set; }
	}
}
