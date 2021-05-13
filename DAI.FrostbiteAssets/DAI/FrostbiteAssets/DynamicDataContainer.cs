using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DynamicDataContainer : DataContainer
	{
		[FieldOffset(8, 24)]
		public List<DataField> Fields { get; set; }

		public DynamicDataContainer()
		{
			Fields = new List<DataField>();
		}
	}
}
