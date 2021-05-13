namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BasicControllerData : CinebotControllerData
	{
		[FieldOffset(24, 112)]
		public ExternalObject<CinebotTransposerData> Transposer { get; set; }

		[FieldOffset(28, 120)]
		public ExternalObject<CinebotComposerData> Composer { get; set; }

		[FieldOffset(32, 128)]
		public float TimeScale { get; set; }
	}
}
