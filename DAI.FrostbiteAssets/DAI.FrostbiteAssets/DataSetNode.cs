using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DataSetNode : UINodeData
	{
		[FieldOffset(20, 64)]
		public ExternalObject<UINodePort> In { get; set; }

		[FieldOffset(24, 72)]
		public ExternalObject<UINodePort> Out { get; set; }

		[FieldOffset(28, 80)]
		public string Param { get; set; }

		[FieldOffset(32, 88)]
		public ExternalObject<Asset> AssetParam { get; set; }

		[FieldOffset(36, 96)]
		public DataSetParamType ParamType { get; set; }

		[FieldOffset(40, 104)]
		public UISimpleDataSource DataSource { get; set; }

		[FieldOffset(48, 120)]
		public bool DoNotCacheData { get; set; }

		[FieldOffset(49, 121)]
		public bool SetToEmptyString { get; set; }

		[FieldOffset(50, 122)]
		public bool ForceUpdate { get; set; }
	}
}
