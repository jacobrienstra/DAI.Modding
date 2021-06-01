namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FaceFXKeyframe : DataContainer
	{
		[FieldOffset(8, 24)]
		public float Time { get; set; }

		[FieldOffset(12, 28)]
		public int Order { get; set; }

		[FieldOffset(16, 32)]
		public ExternalObject<FaceFXAnimset> FaceFXFile { get; set; }

		[FieldOffset(20, 40)]
		public string AnimName { get; set; }

		[FieldOffset(24, 48)]
		public float StartOffset { get; set; }
	}
}
