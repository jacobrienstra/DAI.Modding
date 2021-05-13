using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIElementLayerEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public string LayerName { get; set; }

		[FieldOffset(20, 104)]
		public List<ExternalObject<DataContainer>> Elements { get; set; }

		[FieldOffset(24, 112)]
		public UIElementInclusionSettings InclusionSettings { get; set; }

		[FieldOffset(32, 136)]
		public UICompareDataSource VisibilityDataSource { get; set; }

		[FieldOffset(48, 168)]
		public bool Visible { get; set; }

		public UIElementLayerEntityData()
		{
			Elements = new List<ExternalObject<DataContainer>>();
		}
	}
}
