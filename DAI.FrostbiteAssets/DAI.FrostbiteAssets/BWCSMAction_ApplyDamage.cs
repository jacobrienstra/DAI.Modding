namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_ApplyDamage : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public Delegate_float ComputedDamage { get; set; }

		[FieldOffset(40, 96)]
		public bool DamageFriendlies { get; set; }

		[FieldOffset(41, 97)]
		public bool TriggerDealtMessage { get; set; }

		[FieldOffset(42, 98)]
		public bool TriggerReceivedMessage { get; set; }
	}
}
