namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UICharGenHeadCompData : UIComponentData
	{
		[FieldOffset(32, 136)]
		public float AnalogSliderMoveSpeed { get; set; }

		[FieldOffset(36, 140)]
		public float AnalogSliderDeadZone { get; set; }

		[FieldOffset(40, 144)]
		public LocalizedStringReference RootTitle { get; set; }

		[FieldOffset(44, 168)]
		public LocalizedStringReference DownloadedPresetItemName { get; set; }

		[FieldOffset(48, 192)]
		public LocalizedStringReference CustomPresetItemName { get; set; }
	}
}
