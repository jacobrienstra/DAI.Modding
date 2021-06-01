using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWStartPointLevelDescriptionComponent : LevelDescriptionComponent
	{
		[FieldOffset(8, 24)]
		public List<int> Ids { get; set; }

		[FieldOffset(12, 32)]
		public List<LinearTransform> Transforms { get; set; }

		public BWStartPointLevelDescriptionComponent()
		{
			Ids = new List<int>();
			Transforms = new List<LinearTransform>();
		}
	}
}
