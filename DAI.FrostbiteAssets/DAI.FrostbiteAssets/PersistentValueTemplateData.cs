using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PersistentValueTemplateData : LinkObject
	{
		[FieldOffset(0, 0)]
		public string Name { get; set; }

		[FieldOffset(4, 8)]
		public string DefaultValue { get; set; }

		[FieldOffset(8, 16)]
		public float DefaultFloatValue { get; set; }

		[FieldOffset(12, 20)]
		public PersistentValueType ValueType { get; set; }

		[FieldOffset(16, 24)]
		public PersistentValueDataType DataType { get; set; }

		[FieldOffset(20, 28)]
		public PersistentValueHistoryType HistoryType { get; set; }

		[FieldOffset(24, 32)]
		public bool ClubStat { get; set; }
	}
}
