namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_DisableTarget : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public int TargetIndex { get; set; }

		[FieldOffset(32, 76)]
		public bool Disable { get; set; }

		[FieldOffset(33, 77)]
		public bool ResetOnEnd { get; set; }
	}
}
