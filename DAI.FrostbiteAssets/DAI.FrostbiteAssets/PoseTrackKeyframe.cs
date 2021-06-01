namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PoseTrackKeyframe : TimelineKeyframeData
	{
		[FieldOffset(8, 24)]
		public float Time { get; set; }

		[FieldOffset(12, 32)]
		public ExternalObject<PoseDefinition> TransitionTo { get; set; }

		[FieldOffset(16, 40)]
		public float DurationOverride { get; set; }

		[FieldOffset(20, 48)]
		public ExternalObject<PoseTransitionBase> TransitionOverride { get; set; }
	}
}
