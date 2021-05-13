using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BT_IsInZone : BTEvalFunc
	{
		[FieldOffset(16, 40)]
		public BehaviorZoneType TypeOfZone { get; set; }
	}
}
