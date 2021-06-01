namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CSMStateReference : DataContainer
	{
		[FieldOffset(8, 24)]
		public ExternalObject<BWCSMStateBase> State { get; set; }
	}
}
