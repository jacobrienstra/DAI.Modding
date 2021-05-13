using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class StatusEffect : DataContainerPolicyAsset
	{
		[FieldOffset(12, 72)]
		public UITextureAtlasTextureReference Icon { get; set; }

		[FieldOffset(32, 112)]
		public LocalizedStringReference Description { get; set; }

		[FieldOffset(36, 136)]
		public StatusEffectType EffectType { get; set; }

		[FieldOffset(40, 144)]
		public ExternalObject<IntegerProvider> StackCount { get; set; }

		[FieldOffset(44, 152)]
		public bool IsInnate { get; set; }

		[FieldOffset(45, 153)]
		public bool IsStackable { get; set; }
	}
}
