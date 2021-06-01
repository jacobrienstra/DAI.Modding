namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_SetDefensiveCollisionDisabledLayer : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public int DisabledMask { get; set; }

		[FieldOffset(32, 76)]
		public bool ResetAtEnd { get; set; }

		[FieldOffset(33, 77)]
		public bool DisableLayer { get; set; }
	}
}
