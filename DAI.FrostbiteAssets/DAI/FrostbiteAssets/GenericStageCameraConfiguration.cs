namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class GenericStageCameraConfiguration : SystemSettings
	{
		[FieldOffset(16, 40)]
		public ExternalObject<StageCameraCinebotMode> DefaultStageCameraMode { get; set; }
	}
}
