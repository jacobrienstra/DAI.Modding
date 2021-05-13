using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EquipmentSocketInfoMapping : LinkObject
	{
		[FieldOffset(0, 0)]
		public EquipSlot EquipmentSlot { get; set; }

		[FieldOffset(4, 8)]
		public ExternalObject<BlendedSocketInfo> SocketInfo { get; set; }
	}
}
