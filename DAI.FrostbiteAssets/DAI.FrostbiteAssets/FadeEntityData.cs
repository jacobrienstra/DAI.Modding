namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FadeEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public float FadeTime { get; set; }

		[FieldOffset(20, 100)]
		public float MaxWaitFadedWhileStreamingTime { get; set; }

		[FieldOffset(24, 104)]
		public bool FadeScreen { get; set; }

		[FieldOffset(25, 105)]
		public bool FadeFromTacCam { get; set; }

		[FieldOffset(26, 106)]
		public bool FadeUI { get; set; }

		[FieldOffset(27, 107)]
		public bool FadeAudio { get; set; }

		[FieldOffset(28, 108)]
		public bool FadeMovie { get; set; }

		[FieldOffset(29, 109)]
		public bool FadeRumble { get; set; }

		[FieldOffset(30, 110)]
		public bool BlockInput { get; set; }

		[FieldOffset(31, 111)]
		public bool StartFaded { get; set; }
	}
}
