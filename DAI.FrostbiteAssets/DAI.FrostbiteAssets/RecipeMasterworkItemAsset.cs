namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class RecipeMasterworkItemAsset : StackedItemAsset
	{
		[FieldOffset(104, 304)]
		public ExternalObject<RecipeMaterial> ClothTint { get; set; }

		[FieldOffset(108, 312)]
		public ExternalObject<RecipeMaterial> LeatherTint { get; set; }

		[FieldOffset(112, 320)]
		public ExternalObject<RecipeMaterial> MetalTint { get; set; }

		[FieldOffset(116, 328)]
		public float MasterworkChance { get; set; }

		[FieldOffset(120, 336)]
		public ExternalObject<BWPassiveAbility> Ability { get; set; }
	}
}
