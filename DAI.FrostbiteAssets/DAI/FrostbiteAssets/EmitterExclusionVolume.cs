namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class EmitterExclusionVolume
	{
		[FieldOffset(0, 0)]
		public Vec4 Left { get; set; }

		[FieldOffset(16, 16)]
		public Vec4 Up { get; set; }

		[FieldOffset(32, 32)]
		public Vec4 Forward { get; set; }

		[FieldOffset(48, 48)]
		public Vec4 HalfExtents { get; set; }
	}
}
