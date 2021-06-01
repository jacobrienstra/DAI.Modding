using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DataSourceQueryEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 104)]
		public ExternalObject<Dummy> InData { get; set; }

		[FieldOffset(24, 112)]
		public int ArrayIndex { get; set; }
	}
}
