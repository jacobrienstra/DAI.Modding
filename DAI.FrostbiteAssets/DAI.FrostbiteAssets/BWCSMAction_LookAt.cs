namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_LookAt : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public float Priority { get; set; }

		[FieldOffset(32, 76)]
		public float Time { get; set; }

		[FieldOffset(36, 80)]
		public bool ResetOnEnd { get; set; }
	}
}
