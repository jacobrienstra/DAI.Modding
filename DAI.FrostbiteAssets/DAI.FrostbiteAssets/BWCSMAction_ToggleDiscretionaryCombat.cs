namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_ToggleDiscretionaryCombat : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public bool Enable { get; set; }
	}
}
