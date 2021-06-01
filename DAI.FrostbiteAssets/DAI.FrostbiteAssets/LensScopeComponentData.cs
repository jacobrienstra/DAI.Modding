using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class LensScopeComponentData : VisualEnvironmentComponentData
	{
		[FieldOffset(112, 192)]
		public Vec3 ChromaticAberrationColor1 { get; set; }

		[FieldOffset(128, 208)]
		public Vec3 ChromaticAberrationColor2 { get; set; }

		[FieldOffset(144, 224)]
		public Realm Realm { get; set; }

		[FieldOffset(148, 228)]
		public float BlurScale { get; set; }

		[FieldOffset(152, 232)]
		public Vec2 BlurCenter { get; set; }

		[FieldOffset(160, 240)]
		public Vec2 ChromaticAberrationStrengths { get; set; }

		[FieldOffset(168, 248)]
		public Vec2 ChromaticAberrationDisplacement1 { get; set; }

		[FieldOffset(176, 256)]
		public Vec2 ChromaticAberrationDisplacement2 { get; set; }

		[FieldOffset(184, 264)]
		public Vec2 RadialBlendDistanceCoefficients { get; set; }

		[FieldOffset(192, 272)]
		public bool Enable { get; set; }
	}
}
