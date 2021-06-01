namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_DampMoveStick : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public float ThrottleStrafePercent { get; set; }
	}
}
