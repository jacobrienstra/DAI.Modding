namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_DropLoot : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public ExternalObject<TransformProvider_Select> SafePosition { get; set; }
	}
}
