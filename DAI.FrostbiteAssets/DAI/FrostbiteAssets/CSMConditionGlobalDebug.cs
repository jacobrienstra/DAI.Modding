namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CSMConditionGlobalDebug : BWConditional
	{
		[FieldOffset(8, 32)]
		public int GlobalDebugBitmask { get; set; }
	}
}
