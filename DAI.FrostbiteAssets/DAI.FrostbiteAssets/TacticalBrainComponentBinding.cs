namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class TacticalBrainComponentBinding : LinkObject
	{
		[FieldOffset(0, 0)]
		public AntRef CanStrafe { get; set; }
	}
}
