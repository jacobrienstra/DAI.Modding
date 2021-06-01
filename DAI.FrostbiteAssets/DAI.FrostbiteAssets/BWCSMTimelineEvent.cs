namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMTimelineEvent : DataContainer
	{
		[FieldOffset(8, 24)]
		public float TimeOn { get; set; }

		[FieldOffset(12, 28)]
		public float TimeOff { get; set; }

		[FieldOffset(16, 32)]
		public ExternalObject<BoolProvider> Conditional { get; set; }

		[FieldOffset(20, 40)]
		public bool Disabled { get; set; }
	}
}
