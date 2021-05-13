namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_TriggerStatusEffectFloaty : BWCSMTargetAction
	{
		[FieldOffset(32, 80)]
		public int StatusEffectType { get; set; }
	}
}
