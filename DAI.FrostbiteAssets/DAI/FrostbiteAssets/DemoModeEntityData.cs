namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DemoModeEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public bool TriggerOnStart { get; set; }

		[FieldOffset(17, 97)]
		public bool DisabledInDemoMode { get; set; }
	}
}
