using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class Ps4TitleData : LinkObject
	{
		[FieldOffset(0, 0)]
		public string TitleId { get; set; }

		[FieldOffset(4, 8)]
		public string TitleSecret { get; set; }

		[FieldOffset(8, 16)]
		public List<string> CountryCodes { get; set; }

		public Ps4TitleData()
		{
			CountryCodes = new List<string>();
		}
	}
}
