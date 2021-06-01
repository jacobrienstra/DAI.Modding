namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AnimationGeneratorConfigurations : DataContainer
	{
		[FieldOffset(8, 24)]
		public float MinTimeToGenerateFor { get; set; }

		[FieldOffset(12, 32)]
		public ExternalObject<PerEmotionGeneratorConfiguration> DefaultAnimationSet { get; set; }

		[FieldOffset(16, 40)]
		public ExternalObject<AnimationGeneratorConfiguration> TwitchConfiguration { get; set; }

		[FieldOffset(20, 48)]
		public ExternalObject<AnimationGeneratorConfiguration> GestureConfiguration { get; set; }
	}
}
