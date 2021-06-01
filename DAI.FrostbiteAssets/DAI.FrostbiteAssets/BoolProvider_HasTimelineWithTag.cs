namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BoolProvider_HasTimelineWithTag : BWConditional
	{
		[FieldOffset(8, 32)]
		public BWTimelineTagRef Tag { get; set; }

		[FieldOffset(12, 48)]
		public ExternalObject<EntityProvider> Entity { get; set; }
	}
}
