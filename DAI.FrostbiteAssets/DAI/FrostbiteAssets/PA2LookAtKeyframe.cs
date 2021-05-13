namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PA2LookAtKeyframe : TimelineKeyframeData
	{
		[FieldOffset(8, 24)]
		public float Time { get; set; }

		[FieldOffset(12, 32)]
		public ExternalObject<PA2ConversationLookAtTarget> Target { get; set; }

		[FieldOffset(16, 40)]
		public int Controller { get; set; }

		[FieldOffset(20, 44)]
		public bool SnapToTarget { get; set; }
	}
}
