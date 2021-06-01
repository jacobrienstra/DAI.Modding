namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class UIDamageTypeDisplayInfo : LinkObject
	{
		[FieldOffset(0, 0)]
		public UIElementColor Color { get; set; }

		[FieldOffset(32, 32)]
		public int DamageType { get; set; }

		[FieldOffset(36, 40)]
		public LocalizedStringReference DisplayName { get; set; }

		[FieldOffset(40, 64)]
		public LocalizedStringReference DescriptionTemplate { get; set; }
	}
}
