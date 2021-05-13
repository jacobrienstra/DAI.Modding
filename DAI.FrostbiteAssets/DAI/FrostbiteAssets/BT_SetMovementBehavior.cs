using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BT_SetMovementBehavior : BTTaskFunc
	{
		[FieldOffset(12, 32)]
		public TacticsTarget Target { get; set; }

		[FieldOffset(16, 40)]
		public ExternalObject<MovementBehavior> Behavior { get; set; }
	}
}
