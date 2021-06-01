namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ExertionToEventMapping : DataContainer
	{
		[FieldOffset(8, 24)]
		public int ExertionId { get; set; }

		[FieldOffset(12, 32)]
		public ExternalObject<AudioGraphEvent> Event { get; set; }
	}
}
