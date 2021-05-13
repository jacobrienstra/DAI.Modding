using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AnimationFrequency : DataContainer
	{
		[FieldOffset(8, 24)]
		public AntRef Animation { get; set; }

		[FieldOffset(28, 72)]
		public ANTLayerBlendType BlendType { get; set; }

		[FieldOffset(32, 76)]
		public float Frequency { get; set; }

		[FieldOffset(36, 80)]
		public float MinWeight { get; set; }

		[FieldOffset(40, 84)]
		public float MaxWeight { get; set; }

		[FieldOffset(44, 88)]
		public float MinSpeed { get; set; }

		[FieldOffset(48, 92)]
		public float MaxSpeed { get; set; }

		[FieldOffset(52, 96)]
		public AntRef BlendMaskList { get; set; }

		[FieldOffset(72, 144)]
		public bool OverrideBlendType { get; set; }
	}
}
