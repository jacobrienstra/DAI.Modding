using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class SkyCelestialMultiComponentData : VisualEnvironmentComponentData
	{
		[FieldOffset(112, 192)]
		public Vec3 Tint { get; set; }

		[FieldOffset(128, 208)]
		public Realm Realm { get; set; }

		[FieldOffset(132, 212)]
		public uint DrawOrder { get; set; }

		[FieldOffset(136, 216)]
		public QualityScalableInt QuadCount { get; set; }

		[FieldOffset(152, 232)]
		public ExternalObject<TextureAsset> Texture { get; set; }

		[FieldOffset(156, 240)]
		public Vec2 UVStart { get; set; }

		[FieldOffset(164, 248)]
		public Vec2 UVEnd { get; set; }

		[FieldOffset(172, 256)]
		public Vec2 UVGrid { get; set; }

		[FieldOffset(180, 264)]
		public int RandomSeed { get; set; }

		[FieldOffset(184, 268)]
		public float MinScale { get; set; }

		[FieldOffset(188, 272)]
		public float MaxScale { get; set; }

		[FieldOffset(192, 276)]
		public float ScaleMultiplier { get; set; }

		[FieldOffset(196, 280)]
		public float ZenithStop { get; set; }

		[FieldOffset(200, 284)]
		public float NadirStop { get; set; }

		[FieldOffset(204, 288)]
		public bool Enable { get; set; }

		[FieldOffset(205, 289)]
		public QualityScalableBool EnabledOnQualityLevels { get; set; }

		[FieldOffset(209, 293)]
		public QualityScalableBool PlanarReflection { get; set; }

		[FieldOffset(213, 297)]
		public bool WriteAlpha { get; set; }
	}
}
