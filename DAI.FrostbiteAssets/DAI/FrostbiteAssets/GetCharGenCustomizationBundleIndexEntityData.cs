namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class GetCharGenCustomizationBundleIndexEntityData : BundleIndexEntityData
	{
		[FieldOffset(24, 112)]
		public int CharacterGenderID { get; set; }

		[FieldOffset(28, 116)]
		public int CharacterRaceID { get; set; }
	}
}
