using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MoverTuneMap : LinkObject
	{
		[FieldOffset(0, 0)]
		public List<MoverTuneMapEntry> Index { get; set; }

		public MoverTuneMap()
		{
			Index = new List<MoverTuneMapEntry>();
		}
	}
}
