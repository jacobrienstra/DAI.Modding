namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWRemoveAllPurchasedAbilitiesEntityData : ActionIteratorEntityBaseData
	{
		[FieldOffset(20, 104)]
		public bool ResetAbilityPoints { get; set; }
	}
}
