namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWCSMAction_ClearAOETarget : BWCSMAction_AOETarget
	{
		[FieldOffset(48, 96)]
		public bool ClearAtEnd { get; set; }
	}
}
