using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class FilmGrainComponentData : VisualEnvironmentComponentData
	{
		[FieldOffset(112, 192)]
		public Vec3 ColorScale { get; set; }

		[FieldOffset(128, 208)]
		public Realm Realm { get; set; }

		[FieldOffset(132, 212)]
		public Vec2 TextureScale { get; set; }

		[FieldOffset(140, 224)]
		public ExternalObject<Dummy> Texture { get; set; }

		[FieldOffset(144, 232)]
		public bool Enable { get; set; }

		[FieldOffset(145, 233)]
		public bool LinearFilteringEnable { get; set; }

		[FieldOffset(146, 234)]
		public bool RandomEnable { get; set; }
	}
}
