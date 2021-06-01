namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BT_CheckSharedCooldown : BTEvalFunc
	{
		[FieldOffset(16, 40)]
		public int CooldownId { get; set; }

		[FieldOffset(20, 44)]
		public bool UseAbilitySafety { get; set; }
	}
}
