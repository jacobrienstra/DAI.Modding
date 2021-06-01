using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DataField : LinkObject
	{
		[FieldOffset(0, 0)]
		public string Value { get; set; }

		[FieldOffset(4, 8)]
		public ExternalObject<Dummy> ValueRef { get; set; }

		[FieldOffset(8, 16)]
		public int Id { get; set; }

		[FieldOffset(12, 20)]
		public FieldAccessType AccessType { get; set; }
	}
}
