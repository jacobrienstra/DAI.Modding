namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_VerticalTrajectoryAnimation : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public ExternalObject<FloatProvider_Const> Multiplier { get; set; }
	}
}
