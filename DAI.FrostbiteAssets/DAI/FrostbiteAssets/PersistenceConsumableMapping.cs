using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PersistenceConsumableMapping : LinkObject
	{
		[FieldOffset(0, 0)]
		public ConsumableGroup Group { get; set; }
	}
}
