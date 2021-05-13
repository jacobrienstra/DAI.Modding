namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CSMStateRemapping : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<BWCSMStateAlias> AliasState { get; set; }

		[FieldOffset(4, 8)]
		public ExternalObject<CSMStateReference> StateRef { get; set; }
	}
}
