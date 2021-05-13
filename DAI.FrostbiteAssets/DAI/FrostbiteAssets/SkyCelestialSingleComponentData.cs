using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class SkyCelestialSingleComponentData : VisualEnvironmentComponentData
	{
		[FieldOffset(112, 192)]
		public Vec3 Tint { get; set; }

		[FieldOffset(128, 208)]
		public Realm Realm { get; set; }

		[FieldOffset(132, 212)]
		public uint DrawOrder { get; set; }

		[FieldOffset(136, 216)]
		public ExternalObject<TextureAsset> Texture { get; set; }

		[FieldOffset(140, 224)]
		public Vec2 UVStart { get; set; }

		[FieldOffset(148, 232)]
		public Vec2 UVEnd { get; set; }

		[FieldOffset(156, 240)]
		public float Longitude { get; set; }

		[FieldOffset(160, 244)]
		public float Latitude { get; set; }

		[FieldOffset(164, 248)]
		public float Rotation { get; set; }

		[FieldOffset(168, 252)]
		public Vec2 Scale { get; set; }

		[FieldOffset(176, 260)]
		public bool Enable { get; set; }

		[FieldOffset(177, 261)]
		public QualityScalableBool EnabledOnQualityLevels { get; set; }

		[FieldOffset(181, 265)]
		public QualityScalableBool PlanarReflection { get; set; }

		[FieldOffset(185, 269)]
		public bool WriteAlpha { get; set; }
	}
}
