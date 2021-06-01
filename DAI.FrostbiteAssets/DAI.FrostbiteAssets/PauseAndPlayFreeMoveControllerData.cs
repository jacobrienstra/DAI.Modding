namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class PauseAndPlayFreeMoveControllerData : ThirdPersonGameCameraControllerData
	{
		[FieldOffset(320, 432)]
		public float StartPitch { get; set; }

		[FieldOffset(324, 436)]
		public float AdditionalConfigurableBoomRadius { get; set; }

		[FieldOffset(328, 440)]
		public bool ActivateCharacterSilhouettes { get; set; }
	}
}
