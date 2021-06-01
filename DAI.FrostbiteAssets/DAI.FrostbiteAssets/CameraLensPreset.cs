namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CameraLensPreset : Asset
	{
		[FieldOffset(12, 72)]
		public float DefaultFocalLength { get; set; }

		[FieldOffset(16, 76)]
		public float SensorWidth { get; set; }

		[FieldOffset(20, 80)]
		public float SensorHeight { get; set; }

		[FieldOffset(24, 88)]
		public ExternalObject<Dummy> VisualEnvironment { get; set; }
	}
}
