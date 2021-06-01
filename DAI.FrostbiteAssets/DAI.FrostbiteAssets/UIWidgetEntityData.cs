using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIWidgetEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public UIElementSize Size { get; set; }

		[FieldOffset(24, 104)]
		public List<ExternalObject<DataContainer>> Layers { get; set; }

		[FieldOffset(28, 112)]
		public List<ExternalObject<EntityData>> TextureMappings { get; set; }

		[FieldOffset(32, 120)]
		public List<ExternalObject<DataContainer>> Components { get; set; }

		[FieldOffset(36, 128)]
		public UICompareDataSource VisibilityDataSource { get; set; }

		[FieldOffset(52, 160)]
		public Vec2 Scale { get; set; }

		[FieldOffset(60, 168)]
		public List<Dummy> InputEvents { get; set; }

		[FieldOffset(64, 176)]
		public bool Visible { get; set; }

		public UIWidgetEntityData()
		{
			Layers = new List<ExternalObject<DataContainer>>();
			TextureMappings = new List<ExternalObject<EntityData>>();
			Components = new List<ExternalObject<DataContainer>>();
			InputEvents = new List<Dummy>();
		}
	}
}
