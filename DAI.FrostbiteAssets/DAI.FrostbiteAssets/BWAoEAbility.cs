namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWAoEAbility : BWActivatedAbility
	{
		[FieldOffset(160, 400)]
		public BWManualTargetingParams AoEParams { get; set; }
	}
}
