namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_StartAbilityCooldownTimer : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public bool RestartCooldown { get; set; }

		[FieldOffset(29, 73)]
		public bool RemoveCooldownModifiers { get; set; }
	}
}
