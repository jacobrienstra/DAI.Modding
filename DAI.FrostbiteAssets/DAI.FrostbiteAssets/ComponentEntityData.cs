using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class ComponentEntityData : SpatialEntityData
	{
		[FieldOffset(80, 176)]
		public List<ExternalObject<DataContainer>> Components { get; set; }

		[FieldOffset(84, 184)]
		public byte ClientRuntimeComponentCount { get; set; }

		[FieldOffset(85, 185)]
		public byte ServerRuntimeComponentCount { get; set; }

		[FieldOffset(86, 186)]
		public byte ClientRuntimeTransformationCount { get; set; }

		[FieldOffset(87, 187)]
		public byte ServerRuntimeTransformationCount { get; set; }

		public ComponentEntityData()
		{
			Components = new List<ExternalObject<DataContainer>>();
		}
	}
}
