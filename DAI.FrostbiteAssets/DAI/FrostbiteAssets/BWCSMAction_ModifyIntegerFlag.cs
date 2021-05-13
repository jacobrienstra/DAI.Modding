namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_ModifyIntegerFlag : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public PlotFlagReference PlotFlagReference { get; set; }

		[FieldOffset(44, 112)]
		public int ModifierAmount { get; set; }

		[FieldOffset(48, 116)]
		public bool RemoveAtEnd { get; set; }
	}
}
