namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CinebotItemCameraSettings : ItemCameraSettings
	{
		[FieldOffset(8, 24)]
		public ExternalObject<CinebotModeData> CameraMode { get; set; }

		[FieldOffset(12, 32)]
		public ExternalObject<CinebotModeData> OnCharacterCameraMode { get; set; }
	}
}
