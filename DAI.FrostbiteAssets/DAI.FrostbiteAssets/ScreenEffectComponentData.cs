using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class ScreenEffectComponentData : VisualEnvironmentComponentData
	{
		[FieldOffset(112, 192)]
		public Vec4 ScreenEffectParams { get; set; }

		[FieldOffset(128, 208)]
		public Realm Realm { get; set; }

		[FieldOffset(132, 212)]
		public ScreenEffectFrameType FrameType { get; set; }

		[FieldOffset(136, 216)]
		public ExternalObject<ShaderGraph> Shader { get; set; }

		[FieldOffset(140, 224)]
		public float FrameWidth { get; set; }

		[FieldOffset(144, 228)]
		public float OuterFrameOpacity { get; set; }

		[FieldOffset(148, 232)]
		public float InnerFrameOpacity { get; set; }

		[FieldOffset(152, 236)]
		public float Angle { get; set; }
	}
}
