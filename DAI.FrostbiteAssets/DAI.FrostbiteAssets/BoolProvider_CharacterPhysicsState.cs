using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BoolProvider_CharacterPhysicsState : BoolProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<EntityProvider> Character { get; set; }

		[FieldOffset(12, 40)]
		public CharacterStateType State { get; set; }
	}
}
