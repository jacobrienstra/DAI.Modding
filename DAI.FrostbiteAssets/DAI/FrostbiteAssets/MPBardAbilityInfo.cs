namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MPBardAbilityInfo : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<BWActivatedAbility> Ability { get; set; }

		[FieldOffset(4, 8)]
		public int Code { get; set; }
	}
}
