namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_SetCurrentIdle : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public ExternalObject<CSMStateReference> NewIdleStateRef { get; set; }
	}
}
