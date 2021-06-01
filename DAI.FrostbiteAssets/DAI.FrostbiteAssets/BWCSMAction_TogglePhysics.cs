namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_TogglePhysics : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public bool PhysicsEnabledState { get; set; }

		[FieldOffset(29, 73)]
		public bool ResetAtEnd { get; set; }
	}
}
