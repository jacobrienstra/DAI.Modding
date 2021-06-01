namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWAutoTargetingComponentData : GameComponentData
	{
		[FieldOffset(96, 176)]
		public BWAutoTargetingComponentBinding AnimationBinding { get; set; }

		[FieldOffset(116, 224)]
		public EntryInputOverrideData ManualTargetingInputOverride { get; set; }
	}
}
