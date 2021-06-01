namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIInquisitionCustomizationCompData : UIComponentData
	{
		[FieldOffset(32, 136)]
		public string DisabledColorHexString { get; set; }

		[FieldOffset(36, 144)]
		public string DefaultColorHexString { get; set; }
	}
}
