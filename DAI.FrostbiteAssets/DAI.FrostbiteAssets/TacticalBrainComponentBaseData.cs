namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class TacticalBrainComponentBaseData : GameComponentData
	{
		[FieldOffset(96, 176)]
		public TacticalBrainComponentBinding AnimationBinding { get; set; }
	}
}
