namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CameraSettingsEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public int ZoomLevelDelta { get; set; }

		[FieldOffset(20, 100)]
		public byte ZoomLevels { get; set; }
	}
}
