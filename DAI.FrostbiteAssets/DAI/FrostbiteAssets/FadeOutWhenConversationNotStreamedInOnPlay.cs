namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FadeOutWhenConversationNotStreamedInOnPlay : ConversationNotStreamedInOnStartBehavior
	{
		[FieldOffset(8, 24)]
		public float TimeBeforeFadeOut { get; set; }

		[FieldOffset(12, 28)]
		public float FadeOutTime { get; set; }

		[FieldOffset(16, 32)]
		public float FastFadeInThreshold { get; set; }

		[FieldOffset(20, 36)]
		public float FastFadeInTime { get; set; }

		[FieldOffset(24, 40)]
		public float SlowFadeInTime { get; set; }
	}
}
