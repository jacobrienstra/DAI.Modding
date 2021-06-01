namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PerPoseAnimationFrequency : DataContainer
	{
		[FieldOffset(8, 24)]
		public ExternalObject<PoseDefinition> Pose { get; set; }

		[FieldOffset(12, 32)]
		public ExternalObject<AnimationFrequencyList> TwitchFrequencyList { get; set; }

		[FieldOffset(16, 40)]
		public ExternalObject<AnimationFrequencyList> GestureFrequencyList { get; set; }
	}
}
