namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class CinebotLocatorEntityData : GameComponentEntityData
	{
		[FieldOffset(112, 208)]
		public string CinebotLocatorName { get; set; }

		[FieldOffset(116, 216)]
		public ExternalObject<CinebotLocatorIdentifierAsset> CinebotLocatorIdentifier { get; set; }

		[FieldOffset(120, 224)]
		public string BoneName { get; set; }
	}
}
