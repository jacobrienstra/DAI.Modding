using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BuoyantPartsData
	{
		[FieldOffset(0, 0)]
		public BuoyantParts PartName { get; set; }

		[FieldOffset(4, 4)]
		public float Buoyancy { get; set; }
	}
}
