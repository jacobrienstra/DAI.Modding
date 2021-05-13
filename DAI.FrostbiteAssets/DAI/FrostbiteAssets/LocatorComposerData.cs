namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class LocatorComposerData : CinebotComposerData
	{
		[FieldOffset(40, 128)]
		public string CinebotLocatorName { get; set; }

		[FieldOffset(44, 136)]
		public ExternalObject<CinebotLocatorIdentifierAsset> CinebotLocatorIdentifier { get; set; }

		[FieldOffset(48, 144)]
		public Vec3 Offset { get; set; }

		[FieldOffset(64, 160)]
		public float FOV { get; set; }

		[FieldOffset(68, 164)]
		public float Roll { get; set; }

		[FieldOffset(72, 168)]
		public float NearPlane { get; set; }

		[FieldOffset(76, 172)]
		public float FarPlane { get; set; }
	}
}
