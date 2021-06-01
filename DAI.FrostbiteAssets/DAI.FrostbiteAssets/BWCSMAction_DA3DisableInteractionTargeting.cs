namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_DA3DisableInteractionTargeting : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public bool ClearInteractionTarget { get; set; }
	}
}
