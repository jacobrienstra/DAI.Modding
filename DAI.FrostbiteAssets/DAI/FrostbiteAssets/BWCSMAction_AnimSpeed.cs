using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_AnimSpeed : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public ExternalObject<FloatProvider> Modifier { get; set; }

		[FieldOffset(32, 80)]
		public float EaseIn { get; set; }

		[FieldOffset(36, 84)]
		public float EaseOut { get; set; }

		[FieldOffset(40, 88)]
		public AnimSpeed_ModifierMode Mode { get; set; }
	}
}
