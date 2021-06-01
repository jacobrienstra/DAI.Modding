using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DLCCreditsConfiguration : Asset
	{
		[FieldOffset(12, 72)]
		public List<UIDLCCredits> DLCCredits { get; set; }

		public DLCCreditsConfiguration()
		{
			DLCCredits = new List<UIDLCCredits>();
		}
	}
}
