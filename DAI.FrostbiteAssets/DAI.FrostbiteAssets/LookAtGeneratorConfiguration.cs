namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LookAtGeneratorConfiguration : DataContainer
	{
		[FieldOffset(8, 24)]
		public float MinDelayBeforeLookingAtSpeaker { get; set; }

		[FieldOffset(12, 28)]
		public float MaxDelayBeforeLookingAtSpeaker { get; set; }
	}
}
