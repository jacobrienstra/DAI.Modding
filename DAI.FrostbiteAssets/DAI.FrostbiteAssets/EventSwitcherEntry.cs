namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EventSwitcherEntry : AudioGraphNodePortGroup
	{
		[FieldOffset(8, 24)]
		public AudioGraphNodePort CaseTrigger { get; set; }

		[FieldOffset(16, 56)]
		public float Value { get; set; }
	}
}
