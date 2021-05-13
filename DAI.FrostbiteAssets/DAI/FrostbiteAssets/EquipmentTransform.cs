using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EquipmentTransform : CSMTransformProvider
	{
		[FieldOffset(8, 32)]
		public EquipSlot Slot { get; set; }

		[FieldOffset(12, 36)]
		public bool UseContextSlot { get; set; }

		[FieldOffset(13, 37)]
		public bool IncludeItemVFXTransform { get; set; }
	}
}
