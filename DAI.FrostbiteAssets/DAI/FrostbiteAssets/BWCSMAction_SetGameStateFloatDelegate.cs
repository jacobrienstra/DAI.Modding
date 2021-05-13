namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_SetGameStateFloatDelegate : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public AntRef GameStateFloat { get; set; }

		[FieldOffset(48, 120)]
		public Delegate_float ComputedValue { get; set; }
	}
}
