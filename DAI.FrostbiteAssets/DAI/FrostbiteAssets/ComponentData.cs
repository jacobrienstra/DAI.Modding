using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class ComponentData : GameObjectData
	{
		[FieldOffset(16, 96)]
		public LinearTransform Transform { get; set; }

		[FieldOffset(80, 160)]
		public List<ExternalObject<DataContainer>> Components { get; set; }

		[FieldOffset(84, 168)]
		public bool Excluded { get; set; }

		public ComponentData()
		{
			Components = new List<ExternalObject<DataContainer>>();
		}
	}
}
