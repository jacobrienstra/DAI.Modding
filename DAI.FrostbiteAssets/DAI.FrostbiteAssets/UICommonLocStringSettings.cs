namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UICommonLocStringSettings : BWGameplaySettings
	{
		[FieldOffset(12, 72)]
		public LocalizedStringReference Accept { get; set; }

		[FieldOffset(16, 96)]
		public LocalizedStringReference Back { get; set; }

		[FieldOffset(20, 120)]
		public LocalizedStringReference Cancel { get; set; }

		[FieldOffset(24, 144)]
		public LocalizedStringReference Close { get; set; }

		[FieldOffset(28, 168)]
		public LocalizedStringReference Continue { get; set; }

		[FieldOffset(32, 192)]
		public LocalizedStringReference Error { get; set; }

		[FieldOffset(36, 216)]
		public LocalizedStringReference Exit { get; set; }

		[FieldOffset(40, 240)]
		public LocalizedStringReference No { get; set; }

		[FieldOffset(44, 264)]
		public LocalizedStringReference OK { get; set; }

		[FieldOffset(48, 288)]
		public LocalizedStringReference Quit { get; set; }

		[FieldOffset(52, 312)]
		public LocalizedStringReference Select { get; set; }

		[FieldOffset(56, 336)]
		public LocalizedStringReference Yes { get; set; }
	}
}
