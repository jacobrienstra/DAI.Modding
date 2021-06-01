namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWAbilityTreeInstance : DataContainer
	{
		[FieldOffset(8, 24)]
		public ExternalObject<BWAbilityTree> AbilityTree { get; set; }

		[FieldOffset(12, 32)]
		public bool Unlocked { get; set; }
	}
}
