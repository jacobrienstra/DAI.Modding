namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIQuickbarSlot : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<UIAbilityCommandEntityData> Command { get; set; }

		[FieldOffset(4, 8)]
		public int InputAction { get; set; }

		[FieldOffset(8, 16)]
		public PlotFlagReference UnlockedPlotFlag { get; set; }
	}
}
