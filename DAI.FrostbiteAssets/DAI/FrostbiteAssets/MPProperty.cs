using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MPProperty : DataContainer
	{
		[FieldOffset(8, 24)]
		public MPServerEnums PropertyId { get; set; }

		[FieldOffset(12, 28)]
		public int PropertyValue { get; set; }

		[FieldOffset(16, 32)]
		public int PropertyIntValue { get; set; }

		[FieldOffset(20, 40)]
		public string Preview { get; set; }
	}
}
