using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIElementTextEntry : LinkObject
	{
		[FieldOffset(0, 0)]
		public UITextEntryType TextType { get; set; }

		[FieldOffset(4, 8)]
		public string Text { get; set; }

		[FieldOffset(8, 16)]
		public string FloatFormat { get; set; }

		[FieldOffset(12, 24)]
		public UIDataSource DataSource { get; set; }

		[FieldOffset(24, 48)]
		public bool UseLocalization { get; set; }
	}
}
