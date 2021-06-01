using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIHeadMorphCurve2D : DataContainer
	{
		[FieldOffset(8, 24)]
		public List<Vec2> Points { get; set; }

		public UIHeadMorphCurve2D()
		{
			Points = new List<Vec2>();
		}
	}
}
