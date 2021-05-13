namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CinebotComposerData : CinebotTrackableData
	{
		[FieldOffset(24, 112)]
		public float FocalPlaneOffset { get; set; }

		[FieldOffset(28, 116)]
		public float FStop { get; set; }

		[FieldOffset(32, 120)]
		public float MinimumNearBlur { get; set; }

		[FieldOffset(36, 124)]
		public bool LockTrackable { get; set; }
	}
}
