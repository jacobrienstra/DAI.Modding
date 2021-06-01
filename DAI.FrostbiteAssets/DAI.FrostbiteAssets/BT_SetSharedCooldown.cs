namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BT_SetSharedCooldown : BTTaskFunc
	{
		[FieldOffset(12, 32)]
		public int CooldownId { get; set; }

		[FieldOffset(16, 36)]
		public bool UseAbilitySafety { get; set; }

		[FieldOffset(17, 37)]
		public bool ForceSet { get; set; }
	}
}
