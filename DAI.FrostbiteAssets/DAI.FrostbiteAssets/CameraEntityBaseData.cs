namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class CameraEntityBaseData : SpatialEntityData
	{
		[FieldOffset(80, 176)]
		public string NameId { get; set; }

		[FieldOffset(84, 184)]
		public int Priority { get; set; }

		[FieldOffset(88, 188)]
		public int ViewIndex { get; set; }

		[FieldOffset(92, 192)]
		public ExternalObject<CameraLensPreset> PhysicalCamera { get; set; }

		[FieldOffset(96, 200)]
		public float Exposure { get; set; }

		[FieldOffset(100, 204)]
		public float Aperture { get; set; }

		[FieldOffset(104, 208)]
		public float FocalLength { get; set; }

		[FieldOffset(108, 212)]
		public float FocusDistance { get; set; }

		[FieldOffset(112, 216)]
		public float ShutterSpeed { get; set; }

		[FieldOffset(116, 220)]
		public bool Enabled { get; set; }
	}
}
