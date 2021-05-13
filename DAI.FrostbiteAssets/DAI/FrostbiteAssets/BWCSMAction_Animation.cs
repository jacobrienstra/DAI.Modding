using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_Animation : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public ExternalObject<CSMAnimationType> AnimationType { get; set; }

		[FieldOffset(32, 80)]
		public AntRef AnimationController { get; set; }

		[FieldOffset(52, 128)]
		public int EnumerationValue_TEMP { get; set; }

		[FieldOffset(56, 132)]
		public float StartOffset { get; set; }

		[FieldOffset(60, 136)]
		public float BlendInTime { get; set; }

		[FieldOffset(64, 140)]
		public BWCSMStateBlendType BlendInType { get; set; }

		[FieldOffset(68, 144)]
		public AntRef DofWeightCurves { get; set; }

		[FieldOffset(88, 192)]
		public float Rate { get; set; }

		[FieldOffset(92, 196)]
		public int Animatable { get; set; }

		[FieldOffset(96, 200)]
		public bool Looping { get; set; }

		[FieldOffset(97, 201)]
		public bool Mirror { get; set; }
	}
}
