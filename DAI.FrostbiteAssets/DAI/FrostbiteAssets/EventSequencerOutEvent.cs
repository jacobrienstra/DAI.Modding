namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EventSequencerOutEvent : AudioGraphNodePortGroup
	{
		[FieldOffset(8, 24)]
		public AudioGraphNodePort Out { get; set; }
	}
}
