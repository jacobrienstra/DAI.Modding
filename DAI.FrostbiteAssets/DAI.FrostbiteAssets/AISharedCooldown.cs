using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AISharedCooldown : LinkObject
	{
		[FieldOffset(0, 0)]
		public int CooldownId { get; set; }

		[FieldOffset(4, 4)]
		public AISharedCooldownScope Scope { get; set; }

		[FieldOffset(8, 8)]
		public ExternalObject<FloatProvider_Const> Duration { get; set; }
	}
}
