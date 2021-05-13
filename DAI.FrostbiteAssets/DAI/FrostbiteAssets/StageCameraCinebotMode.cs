namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class StageCameraCinebotMode : DataContainer
	{
		[FieldOffset(8, 24)]
		public ExternalObject<CinebotModeData> Mode { get; set; }

		[FieldOffset(12, 32)]
		public ExternalObject<StageTrackableSettingsSimple> PlacedCamera { get; set; }

		[FieldOffset(16, 40)]
		public ExternalObject<StageTrackableSettingsHeightAdjustment> PlacedCameraAttachedToLookFrom { get; set; }

		[FieldOffset(20, 48)]
		public ExternalObject<Dummy> PlacedCameraAttachedToLookAt { get; set; }

		[FieldOffset(24, 56)]
		public ExternalObject<StageTrackableSettingsHeightAdjustment> PlacedCenterScreenAttachedToLookAt { get; set; }

		[FieldOffset(28, 64)]
		public ExternalObject<StageTrackableSettingsSimple> LookFromCharacter { get; set; }

		[FieldOffset(32, 72)]
		public ExternalObject<Dummy> LookAtCharacter { get; set; }

		[FieldOffset(36, 80)]
		public bool GlobalMode { get; set; }
	}
}
