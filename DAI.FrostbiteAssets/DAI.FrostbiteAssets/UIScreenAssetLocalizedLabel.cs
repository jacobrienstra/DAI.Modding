namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIScreenAssetLocalizedLabel : LinkObject
	{
		[FieldOffset(0, 0)]
		public string LabelId { get; set; }

		[FieldOffset(4, 8)]
		public LocalizedStringReference LocString { get; set; }
	}
}
