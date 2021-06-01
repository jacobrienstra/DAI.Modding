using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BoundaryEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public List<LinearTransform> HardBoundaryBoxes { get; set; }

		public BoundaryEntityData()
		{
			HardBoundaryBoxes = new List<LinearTransform>();
		}
	}
}
