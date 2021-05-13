namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIChallengeCompData : UIComponentData
	{
		[FieldOffset(32, 136)]
		public UITextureAtlasTextureReference DefaultChallengeIcon { get; set; }

		[FieldOffset(52, 176)]
		public float ChallengeTrackingTime { get; set; }

		[FieldOffset(56, 180)]
		public float TimeChallengeTrackingTime { get; set; }
	}
}
