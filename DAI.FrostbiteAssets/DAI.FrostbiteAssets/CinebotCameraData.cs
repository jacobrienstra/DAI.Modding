namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class CinebotCameraData : TargetCameraData
	{
		[FieldOffset(160, 272)]
		public ExternalObject<CinebotGlobalCameraDirectorData> Director { get; set; }
	}
}
