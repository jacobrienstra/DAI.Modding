namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_SuppressEscapeMenu : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public bool OnlyIfTriggered { get; set; }
	}
}
