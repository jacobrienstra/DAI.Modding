namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class LocatorTransposerData : CinebotTransposerData
	{
		[FieldOffset(28, 120)]
		public string CinebotLocatorName { get; set; }

		[FieldOffset(32, 128)]
		public Vec3 Offset { get; set; }

		[FieldOffset(48, 144)]
		public ExternalObject<CinebotLocatorIdentifierAsset> CinebotLocatorIdentifier { get; set; }
	}
}
