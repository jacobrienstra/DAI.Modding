using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ColorPalette : Asset
	{
		[FieldOffset(12, 72)]
		public string SourcePath { get; set; }

		[FieldOffset(16, 80)]
		public List<Vec3> Entries { get; set; }

		public ColorPalette()
		{
			Entries = new List<Vec3>();
		}
	}
}
