namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class LocalWindForceBaked3DAs2x2DTexEntityData : LocalWindForceEntityBaseData
	{
		[FieldOffset(112, 208)]
		public Vec3 VolumeSliceZXScale { get; set; }

		[FieldOffset(128, 224)]
		public Vec3 VolumeSliceZYScale { get; set; }

		[FieldOffset(144, 240)]
		public float SizeX { get; set; }

		[FieldOffset(148, 244)]
		public float SizeY { get; set; }

		[FieldOffset(152, 248)]
		public float SizeZ { get; set; }

		[FieldOffset(156, 252)]
		public float Attenuation { get; set; }

		[FieldOffset(160, 256)]
		public ExternalObject<TextureAsset> VolumeSliceZX { get; set; }

		[FieldOffset(164, 264)]
		public ExternalObject<TextureAsset> VolumeSliceZY { get; set; }
	}
}
