namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_GravityMultiplier : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public float Multiplier { get; set; }
	}
}
