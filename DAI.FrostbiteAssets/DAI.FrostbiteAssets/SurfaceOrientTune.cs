namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SurfaceOrientTune : Asset
	{
		[FieldOffset(12, 72)]
		public float surfaceOrientThreshold { get; set; }

		[FieldOffset(16, 76)]
		public float surfaceOrientSlerpTime { get; set; }

		[FieldOffset(20, 80)]
		public bool alwaysVerticalOnAutoGen { get; set; }
	}
}
