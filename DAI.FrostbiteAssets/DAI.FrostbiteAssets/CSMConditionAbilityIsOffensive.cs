namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CSMConditionAbilityIsOffensive : BWConditional
	{
		[FieldOffset(8, 32)]
		public bool NoAbilityReturn { get; set; }
	}
}
