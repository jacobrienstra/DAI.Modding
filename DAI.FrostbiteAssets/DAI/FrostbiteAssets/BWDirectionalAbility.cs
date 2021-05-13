namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWDirectionalAbility : BWActivatedAbility
	{
		[FieldOffset(152, 400)]
		public BWTargetingParams Params { get; set; }
	}
}
