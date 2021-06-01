namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class UIStatusEffectDisplayInfo : LinkObject
	{
		[FieldOffset(0, 0)]
		public UIElementColor Color { get; set; }

		[FieldOffset(32, 32)]
		public int StatusEffectType { get; set; }

		[FieldOffset(36, 40)]
		public LocalizedStringReference DisplayName { get; set; }
	}
}
