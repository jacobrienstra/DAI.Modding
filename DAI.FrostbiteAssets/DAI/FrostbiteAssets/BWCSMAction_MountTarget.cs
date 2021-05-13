namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_MountTarget : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public AntRef RiderID { get; set; }

		[FieldOffset(48, 120)]
		public bool EnterRepulsorState { get; set; }

		[FieldOffset(49, 121)]
		public bool ExitRepulsorState { get; set; }
	}
}
