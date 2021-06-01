using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MaterialInteractionGridRow : LinkObject
	{
		[FieldOffset(0, 0)]
		public List<MaterialRelationPropertyPair> Items { get; set; }

		public MaterialInteractionGridRow()
		{
			Items = new List<MaterialRelationPropertyPair>();
		}
	}
}
