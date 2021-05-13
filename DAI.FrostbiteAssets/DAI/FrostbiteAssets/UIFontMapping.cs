using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIFontMapping : LinkObject
	{
		[FieldOffset(0, 0)]
		public List<string> ScaleformFontName { get; set; }

		[FieldOffset(4, 8)]
		public string FontLongName { get; set; }

		[FieldOffset(8, 16)]
		public float ScalingFactor { get; set; }

		[FieldOffset(12, 20)]
		public bool Bold { get; set; }

		public UIFontMapping()
		{
			ScaleformFontName = new List<string>();
		}
	}
}
