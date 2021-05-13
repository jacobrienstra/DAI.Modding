namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class SoundEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public LinearTransform Transform { get; set; }

		[FieldOffset(80, 160)]
		public ExternalObject<SoundAsset> Sound { get; set; }

		[FieldOffset(84, 168)]
		public float OcclusionValue { get; set; }

		[FieldOffset(88, 172)]
		public bool PlayOnCreation { get; set; }

		[FieldOffset(89, 173)]
		public bool EnableOnCreation { get; set; }

		[FieldOffset(90, 174)]
		public bool UseParentTransform { get; set; }
	}
}
