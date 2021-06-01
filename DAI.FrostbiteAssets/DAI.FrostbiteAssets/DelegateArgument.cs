namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DelegateArgument : DataContainer
	{
		[FieldOffset(8, 24)]
		public int EngineArgumentIndex { get; set; }
	}
}
