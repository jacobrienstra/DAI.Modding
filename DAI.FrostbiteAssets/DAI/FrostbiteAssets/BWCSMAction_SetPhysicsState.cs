using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_SetPhysicsState : BWCSMAction
	{
		[FieldOffset(28, 72)]
		public CharacterStateType PhysicsState { get; set; }
	}
}
